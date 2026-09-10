public interface ISalesService
{
  Task<ICollection<Sale>> Sales();
  Task<Sale> Sale(Guid id);
  Task<Sale> NewSale(SaleDto saleDto);
  Task<PagedResponse<Sale>> GetSalesPaginated(PaginationParams paginationParams);
}