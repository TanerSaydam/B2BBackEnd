using Microsoft.AspNetCore.Http;

namespace Entities.Dtos
{
    public class ProductImageAddDto
    {
        public int ProductId { get; set; }
        public IFormFile[] Images { get; set; }
    }
}
