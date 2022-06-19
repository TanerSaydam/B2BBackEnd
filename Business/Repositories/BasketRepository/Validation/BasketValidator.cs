using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.BasketRepository.Validation
{
    public class BasketValidator : AbstractValidator<Basket>
    {
        public BasketValidator()
        {
        }
    }
}
