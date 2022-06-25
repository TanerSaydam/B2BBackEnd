using Entities.Concrete;

namespace Entities.Dtos
{
    public class OrderDetailDto : OrderDetail
    {
        public string ProductName { get; set; }
        public decimal Total { get; set; }
    }
}
