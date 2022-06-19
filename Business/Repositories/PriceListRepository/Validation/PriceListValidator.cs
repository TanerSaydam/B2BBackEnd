using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.PriceListRepository.Validation
{
    public class PriceListValidator : AbstractValidator<PriceList>
    {
        public PriceListValidator()
        {
        }
    }
}
