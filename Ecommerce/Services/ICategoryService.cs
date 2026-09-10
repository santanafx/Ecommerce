public interface ICategoryService
{
  Task<Category> AddCategory(CategoryDto categoryDto);
  Task<Category> RemoveCategory(int id);
  Task<ICollection<Category>> Categories();
}
