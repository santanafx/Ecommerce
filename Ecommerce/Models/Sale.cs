public class Sale
{
  public Guid Id { get; private set; }
  public DateTime CreatedAt { get; private set; }
  public ICollection<Product> ProductsList { get; private set; }
  public decimal Total { get; private set; }
  public ICollection<ProductSaleItem> Products { get; private set; }

  private Sale() { }

  public Sale(SaleDto dto)
  {
    Id = Guid.NewGuid();
    ProductsList = dto.ProductsList;
    CreatedAt = DateTime.UtcNow;
    Total = dto.ProductsList.Sum(p => p.Price);
  }
}