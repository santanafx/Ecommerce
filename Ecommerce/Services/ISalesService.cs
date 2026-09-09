public interface ISalesService
{
  ICollection<Sale> Sales();
  Sale Sale(Guid id);
  Sale NewSale(SaleDto saleDto);
}