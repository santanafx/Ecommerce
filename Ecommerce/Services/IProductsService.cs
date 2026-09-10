public interface IProductsService
{
  Task<ICollection<Product>> Products();
  Task<PagedResponse<Product>> GetProductsPaginated(PaginationParams paginationParams);
  Task<Product> AddProduct(ProductDto productDto);
  Task<Product> RemoveProduct(Guid id);
  Task<Product> UpdateProduct(Guid id, ProductDto productDto);
  Task<Product> Product(Guid id);
}