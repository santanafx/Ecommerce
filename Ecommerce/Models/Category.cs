public class Category
{
  public Guid Id { get; private set; }
  public string Name { get; set; }
  public ICollection<Product> Products { get; private set; }

  private Category() { }

  public Category(CategoryDto dto)
  {
    Id = Guid.NewGuid();
    Name = dto.Name;
  }
}