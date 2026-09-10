using Microsoft.EntityFrameworkCore;

public class SalesService : ISalesService
{
  private readonly DbContextEcommerce _dbContextEcommerce;

  public SalesService(DbContextEcommerce dbContextEcommerce)
  {
    _dbContextEcommerce = dbContextEcommerce;
  }

  public async Task<PagedResponse<SaleResponseDto>> GetSalesPaginated(PaginationParams paginationParams)
  {
    var query = _dbContextEcommerce.Sales.AsQueryable();

    if (!string.IsNullOrEmpty(paginationParams.SearchTerm))
      query = query.Where(p => p.Id.ToString().Contains(paginationParams.SearchTerm));

    var totalRecords = await query.CountAsync();

    var sales = await query
      .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
      .Take(paginationParams.PageSize)
      .ToListAsync();

    var dtos = sales.Select(MapToDto).ToList();
    return new PagedResponse<SaleResponseDto>(dtos, paginationParams.PageNumber, paginationParams.PageSize, totalRecords);
  }

  public async Task<SaleResponseDto> NewSale(SaleDto saleDto)
  {
    var productIds = saleDto.ProductsList.Select(p => p.ProductId).ToList();
    var products = await _dbContextEcommerce.Products
      .Where(p => productIds.Contains(p.Id))
      .ToListAsync();

    var productsLookup = products.ToDictionary(p => p.Id);

    var saleItems = saleDto.ProductsList.Select(item =>
    {
      var product = productsLookup[item.ProductId];
      product.DecreaseStock(item.Quantity);
      return new ProductSaleItem(new ProductSaleItemDto
      {
        ProductId = item.ProductId,
        SaleId = 0,
        Quantity = item.Quantity,
        UnitPrice = product.Price
      });
    }).ToList();

    var sale = new Sale(saleItems);

    _dbContextEcommerce.Sales.Add(sale);
    await _dbContextEcommerce.SaveChangesAsync();

    return MapToDto(sale);
  }

  public async Task<SaleResponseDto> Sale(int id)
  {
    var sale = await _dbContextEcommerce.Sales.FindAsync(id);
    return sale == null ? null : MapToDto(sale);
  }

  public async Task<ICollection<SaleResponseDto>> Sales()
  {
    var sales = await _dbContextEcommerce.Sales.ToListAsync();
    return sales.Select(MapToDto).ToList();
  }

  private static SaleResponseDto MapToDto(Sale sale)
  {
    return new SaleResponseDto
    {
      Id = sale.Id,
      CreatedAt = sale.CreatedAt,
      Total = sale.Total,
      Products = sale.Products?.Select(p => new SaleItemResponseDto
      {
        ProductId = p.ProductId,
        Quantity = p.Quantity,
        UnitPrice = p.UnitPrice
      }).ToList()
    };
  }
}
