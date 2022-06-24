using Entities.Concrete;

namespace Entities.Dtos
{
    public class CustomerDto : Customer
    {
        public int? PriceListId { get; set; }
        public string? PriceListName { get; set; }
        public decimal? Discount { get; set; }
    }
}
