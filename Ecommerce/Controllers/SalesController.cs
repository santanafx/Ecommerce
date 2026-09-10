using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class SalesController : ControllerBase
{
  private readonly ISalesService _salesService;

  public SalesController(ISalesService salesService)
  {
    _salesService = salesService;
  }

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    return Ok(await _salesService.Sales());
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> Get(Guid id)
  {
    return Ok(await _salesService.Sale(id));
  }

  [HttpGet("paginated")]
  public async Task<IActionResult> GetPaginated([FromQuery] PaginationParams paginationParams)
  {
    return Ok(await _salesService.GetSalesPaginated(paginationParams));
  }

  [HttpPost]
  public async Task<IActionResult> Post([FromBody] SaleDto saleDto)
  {
    return Ok(await _salesService.NewSale(saleDto));
  }
}