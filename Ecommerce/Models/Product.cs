public class Product
{
  public int Id { get; private set; }
  public string Name { get; private set; }
  public string Description { get; private set; }
  public decimal Price { get; private set; }
  public int StockQuantity { get; private set; }
  public int CategoryId { get; private set; }
  public Category Category { get; private set; }
  public ICollection<ProductSaleItem> Sales { get; private set; }

  private Product() { }

  public Product(ProductDto dto)
  {
    Name = dto.Name;
    Description = dto.Description;
    Price = dto.Price;
    StockQuantity = dto.StockQuantity;
    CategoryId = dto.CategoryId;
  }

  public void Update(ProductDto dto)
  {
    Name = dto.Name;
    Description = dto.Description;
    Price = dto.Price;
    StockQuantity = dto.StockQuantity;
    CategoryId = dto.CategoryId;
  }

  public void DecreaseStock(int quantity)
  {
    if (StockQuantity <= 0)
      throw new ArgumentException($"Product {Name} is out of stock");

    if (quantity > StockQuantity)
      throw new ArgumentException($"Insufficient stock for {Name}. Available: {StockQuantity}");

    StockQuantity -= quantity;
  }
}
