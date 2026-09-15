public class Category
{
  public int Id { get; private set; }
  public string Name { get; set; }
  public bool IsDeleted { get; private set; }
  public DateTime? DeletedAt { get; private set; }
  public ICollection<Product> Products { get; private set; }

  private Category() { }

  public Category(CategoryDto dto)
  {
    Name = dto.Name;
  }

  public void SoftDelete()
  {
    IsDeleted = true;
    DeletedAt = DateTime.UtcNow;
  }
}
