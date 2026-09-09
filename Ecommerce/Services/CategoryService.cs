
public class CategoryService : ICategoryService
{
  private readonly DbContextEcommerce _dbContextEcommerce;
  public CategoryService(DbContextEcommerce dbContextEcommerce)
  {
    _dbContextEcommerce = dbContextEcommerce;
  }

  public async Task<Category> AddCategory(CategoryDto categoryDto)
  {
    if (string.IsNullOrEmpty(categoryDto.Name))
      throw new ArgumentException("Name is required");

    var category = new Category(categoryDto);
    _dbContextEcommerce.Categories.Add(category);
    _dbContextEcommerce.SaveChanges();

    return category;
  }

  public async Task<ICollection<Category>> Categories()
  {
    return _dbContextEcommerce.Categories.ToList();
  }

  public async Task<Category> RemoveCategory(Guid id)
  {
    if (_dbContextEcommerce.Categories.Find(id) == null)
      throw new ArgumentException("Category id doesnt exist");

    return _dbContextEcommerce.Categories.Find(id);
  }
}