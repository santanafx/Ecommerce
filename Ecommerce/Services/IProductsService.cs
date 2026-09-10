public interface IProductsService
{
  Task<ICollection<Product>> Products();
  Task<PagedResponse<Product>> GetProductsPaginated(PaginationParams paginationParams);
  Task<Product> AddProduct(ProductDto productDto);
  Task<Product> RemoveProduct(int id);
  Task<Product> UpdateProduct(int id, ProductDto productDto);
  Task<Product> Product(int id);
}
