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
  public ActionResult<Category> AddCategory([FromBody] Category category)
  {
    return Ok(_categoryService.AddCategory(category));
  }

  [HttpGet]
  public ActionResult<ICollection<Category>> Categories()
  {
    return Ok(_categoryService.Categories());
  }

  [HttpDelete]
  public ActionResult<Category> RemoveCategory(Guid id)
  {
    return Ok(_categoryService.RemoveCategory(id));
  }
}