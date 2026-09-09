public interface ICategoryService
{
  Task<Category> AddCategory(CategoryDto categoryDto);
  Task<Category> RemoveCategory(Guid id);
  Task<ICollection<Category>> Categories();
}