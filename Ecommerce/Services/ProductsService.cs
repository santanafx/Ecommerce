using Microsoft.EntityFrameworkCore;

public class ProductsService : IProductsService
{
  private readonly DbContextEcommerce _dbContextEcommerce;

  public ProductsService(DbContextEcommerce dbContextEcommerce)
  {
    _dbContextEcommerce = dbContextEcommerce;
  }

  public async Task<Product> AddProduct(ProductDto productDto)
  {
    if (string.IsNullOrEmpty(productDto.Name))
      throw new ArgumentException("Name is required");

    if (productDto.Price < 0)
      throw new ArgumentException("Price must be greater than zero");

    if (productDto.StockQuantity < 0)
      throw new ArgumentException("StockQuantity must be greater than zero");

    if (!_dbContextEcommerce.Categories.Any(c => c.Id == productDto.CategoryId))
      throw new ArgumentException($"Category {productDto.CategoryId} doesnt exist");

    if (_dbContextEcommerce.Products.Any(p => p.Name == productDto.Name))
      throw new ArgumentException("This product already exists");

    var product = new Product(productDto);
    _dbContextEcommerce.Products.Add(product);
    _dbContextEcommerce.SaveChanges();

    return product;
  }

  public async Task<Product> Product(Guid id)
  {
    if (id == Guid.Empty)
      throw new ArgumentException("User must provide id");

    if (_dbContextEcommerce.Products.Find(id) == null)
      throw new ArgumentException("The product id doesnt exist");

    var product = _dbContextEcommerce.Products.Find(id);
    return product;
  }

  public async Task<ICollection<Product>> Products()
  {
    var products = _dbContextEcommerce.Products.ToList();
    return products;
  }

  public async Task<PagedResponse<Product>> GetProductsPaginated(PaginationParams paginationParams)
  {
    var query = _dbContextEcommerce.Products.AsQueryable();

    if (!string.IsNullOrEmpty(paginationParams.SearchTerm))
      query = query.Where(p => p.Name.Contains(paginationParams.SearchTerm));

    if (paginationParams.CategoryId.HasValue)
      query = query.Where(p => p.CategoryId == paginationParams.CategoryId.Value);

    var totalRecords = await query.CountAsync();

    var products = await query
      .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
      .Take(paginationParams.PageSize)
      .ToListAsync();

    return new PagedResponse<Product>(products, paginationParams.PageNumber, paginationParams.PageSize, totalRecords);
  }

  public async Task<Product> RemoveProduct(Guid id)
  {
    if (id == Guid.Empty)
      throw new ArgumentException("User must provide id");

    var product = _dbContextEcommerce.Products.Find(id);
    if (product == null)
      throw new ArgumentException("The product id doesnt exist");

    _dbContextEcommerce.Products.Remove(product);
    _dbContextEcommerce.SaveChanges();

    return product;
  }

  public async Task<Product> UpdateProduct(Guid id, ProductDto productDto)
  {
    if (id == Guid.Empty)
      throw new ArgumentException("User must provide id");

    var productFoundInDatabase = _dbContextEcommerce.Products.Find(id);
    if (productFoundInDatabase == null)
      throw new ArgumentException("The product id doesnt exist");

    if (string.IsNullOrEmpty(productDto.Name))
      throw new ArgumentException("Name cant be empty");

    if (productDto.Price < 0)
      throw new ArgumentException("Price must be greater than zero");

    if (productDto.StockQuantity < 0)
      throw new ArgumentException("StockQuantity must be greater than zero");

    productFoundInDatabase.Update(productDto);

    _dbContextEcommerce.Products.Update(productFoundInDatabase);
    _dbContextEcommerce.SaveChanges();

    return productFoundInDatabase;
  }
}