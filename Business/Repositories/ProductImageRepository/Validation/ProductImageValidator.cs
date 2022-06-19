using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.ProductImageRepository.Validation
{
    public class ProductImageValidator : AbstractValidator<ProductImage>
    {
        public ProductImageValidator()
        {
        }
    }
}
