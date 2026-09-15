public class Sale
{
  public int Id { get; private set; }
  public DateTime CreatedAt { get; private set; }
  public decimal Total { get; private set; }
  public bool IsDeleted { get; private set; }
  public DateTime? DeletedAt { get; private set; }
  public ICollection<ProductSaleItem> Products { get; private set; }

  private Sale() { }

  public Sale(ICollection<ProductSaleItem> products)
  {
    CreatedAt = DateTime.UtcNow;
    Products = products;
    Total = products.Sum(p => p.Quantity * p.UnitPrice);
  }

  public void SoftDelete()
  {
    IsDeleted = true;
    DeletedAt = DateTime.UtcNow;
  }
}
