using Entities.Concrete;

namespace Entities.Dtos
{
    public class ProductListDto : Product
    {
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string MainImageUrl { get; set; }
        public List<string> Images { get; set; }
    }
}
