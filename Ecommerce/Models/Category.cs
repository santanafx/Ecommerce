public class Category
{
  public int Id { get; private set; }
  public string Name { get; set; }
  public ICollection<Product> Products { get; private set; }

  private Category() { }

  public Category(CategoryDto dto)
  {
    Name = dto.Name;
  }
}
