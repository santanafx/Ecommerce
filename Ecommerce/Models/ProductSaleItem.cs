public class ProductSaleItem
{
  public Guid Id { get; private set; }
  public Guid ProductId { get; private set; }
  public Product Product { get; private set; }
  public Guid SaleId { get; private set; }
  public Sale Sale { get; private set; }
  public int Quantity { get; private set; }
  public decimal UnitPrice { get; private set; }

}