using Entities.Concrete;

namespace Entities.Dtos
{
    public class OrderDto : Order
    {
        public string CustomerName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
