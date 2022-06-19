namespace Entities.Concrete
{
    public class PriceListDetail
    {
        public int Id { get; set; }
        public int PriceListId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
    }
}
