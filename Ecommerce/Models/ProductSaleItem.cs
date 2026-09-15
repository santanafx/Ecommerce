public class ProductSaleItem
{
  public int Id { get; private set; }
  public int ProductId { get; private set; }
  public Product Product { get; private set; }
  public int SaleId { get; private set; }
  public Sale Sale { get; private set; }
  public int Quantity { get; private set; }
  public decimal UnitPrice { get; private set; }
  public bool IsDeleted { get; private set; }
  public DateTime? DeletedAt { get; private set; }

  private ProductSaleItem() { }

  public ProductSaleItem(ProductSaleItemDto dto)
  {
    ProductId = dto.ProductId;
    SaleId = dto.SaleId;
    Quantity = dto.Quantity;
    UnitPrice = dto.UnitPrice;
  }

  public void SoftDelete()
  {
    IsDeleted = true;
    DeletedAt = DateTime.UtcNow;
  }
}
