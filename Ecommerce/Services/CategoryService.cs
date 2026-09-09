
public class CategoryService : ICategoryService
{
  private readonly DbContextEcommerce _dbContextEcommerce;
  public CategoryService(DbContextEcommerce dbContextEcommerce)
  {
    _dbContextEcommerce = dbContextEcommerce;
  }

  public Category AddCategory(Category category)
  {
    if (string.IsNullOrEmpty(category.Name))
      throw new ArgumentException("Name is required");

    _dbContextEcommerce.Categories.Add(category);
    _dbContextEcommerce.SaveChanges();

    return category;
  }

  public ICollection<Category> Categories()
  {
    return _dbContextEcommerce.Categories.ToList();
  }

  public Category RemoveCategory(Guid id)
  {
    if (_dbContextEcommerce.Categories.Find(id) == null)
      throw new ArgumentException("Category id doesnt exist");

    return _dbContextEcommerce.Categories.Find(id);
  }
}