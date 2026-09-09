public class Category
{
  public Guid Id { get; private set; }
  public string Name { get; set; }
  public ICollection<Product> Products { get; private set; }

}