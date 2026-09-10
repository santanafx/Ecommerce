using Microsoft.EntityFrameworkCore;

public class SalesService : ISalesService
{
  private readonly DbContextEcommerce _dbContextEcommerce;

  public SalesService(DbContextEcommerce dbContextEcommerce)
  {
    _dbContextEcommerce = dbContextEcommerce;

  }

  public async Task<PagedResponse<Sale>> GetSalesPaginated(PaginationParams paginationParams)
  {
    var query = _dbContextEcommerce.Sales.AsQueryable();

    if (!string.IsNullOrEmpty(paginationParams.SearchTerm))
      query = query.Where(p => p.Id.ToString().Contains(paginationParams.SearchTerm));

    var totalRecords = await query.CountAsync();

    var sales = await query
      .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
      .Take(paginationParams.PageSize)
      .ToListAsync();

    return new PagedResponse<Sale>(sales, paginationParams.PageNumber, paginationParams.PageSize, totalRecords);
  }


  public async Task<Sale> NewSale(SaleDto saleDto)
  {
    var sale = new Sale(saleDto);

    _dbContextEcommerce.Sales.Add(sale);
    await _dbContextEcommerce.SaveChangesAsync();

    return sale;
  }

  public async Task<Sale> Sale(Guid id)
  {
    return await _dbContextEcommerce.Sales.FindAsync(id);
  }

  public async Task<ICollection<Sale>> Sales()
  {
    return await _dbContextEcommerce.Sales.ToListAsync();

  }
}