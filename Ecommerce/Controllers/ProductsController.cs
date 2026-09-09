using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
  private readonly IProductsService _productsService;
  public ProductsController(IProductsService productsService)
  {
    _productsService = productsService;
  }

  [HttpGet]
  public async Task<IActionResult> Products()
  {
    return Ok(_productsService.Products());
  }

  [HttpPost]
  public async Task<ActionResult<Product>> AddProducts([FromBody] ProductDto productDto)
  {
    return Ok(await _productsService.AddProduct(productDto));
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult<Product>> RemoveProduct(Guid id)
  {
    return Ok(_productsService.RemoveProduct(id));
  }

  [HttpGet("{id}")]
  public async Task<ActionResult> Product(Guid id)
  {
    return Ok(_productsService.Product(id));
  }

  [HttpPut("{id}")]
  public async Task<ActionResult<Product>> UpdateProduct(Guid id, ProductDto productDto)
  {
    return Ok(_productsService.UpdateProduct(id, productDto));
  }
}