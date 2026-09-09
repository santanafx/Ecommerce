public interface ICategoryService
{
  Category AddCategory(Category category);
  Category RemoveCategory(Guid id);
  ICollection<Category> Categories();

}