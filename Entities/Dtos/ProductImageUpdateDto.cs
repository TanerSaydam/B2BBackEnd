using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Entities.Dtos
{
    public class ProductImageUpdateDto : ProductImage
    {
        public IFormFile Image { get; set; }
    }
}
