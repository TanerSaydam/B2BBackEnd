using Entities.Concrete;

namespace Entities.Dtos
{
    public class BasketListDto : Basket
    {
        public string ProductName { get; set; }
        public decimal Total { get; set; }
    }
}
