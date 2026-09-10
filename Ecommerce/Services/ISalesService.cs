public interface ISalesService
{
  Task<ICollection<SaleResponseDto>> Sales();
  Task<SaleResponseDto> Sale(int id);
  Task<SaleResponseDto> NewSale(SaleDto saleDto);
  Task<PagedResponse<SaleResponseDto>> GetSalesPaginated(PaginationParams paginationParams);
}
