using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
  private readonly ICategoryService _categoryService;
  public CategoriesController(ICategoryService categoryService)
  {
    _categoryService = categoryService;
  }

  [HttpPost]
  public async Task<ActionResult<Category>> AddCategory([FromBody] CategoryDto categoryDto)
  {
    return Ok(_categoryService.AddCategory(categoryDto));
  }

  [HttpGet]
  public async Task<ActionResult<ICollection<Category>>> Categories()
  {
    return Ok(_categoryService.Categories());
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult<Category>> RemoveCategory(int id)
  {
    return Ok(_categoryService.RemoveCategory(id));
  }
}
