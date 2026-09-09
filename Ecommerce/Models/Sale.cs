public class Sale
{
  public Guid Id { get; private set; }
  public string Name { get; private set; }
  public DateTime CreatedAt { get; private set; }
  public decimal Total { get; private set; }
  public ICollection<ProductSaleItem> Products { get; private set; }

}