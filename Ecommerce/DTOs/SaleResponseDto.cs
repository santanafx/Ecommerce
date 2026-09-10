public class SaleResponseDto
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public decimal Total { get; set; }
  public ICollection<SaleItemResponseDto> Products { get; set; }
}
