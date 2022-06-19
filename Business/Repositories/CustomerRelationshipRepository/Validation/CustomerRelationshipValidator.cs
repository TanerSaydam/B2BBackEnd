using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.CustomerRelationshipRepository.Validation
{
    public class CustomerRelationshipValidator : AbstractValidator<CustomerRelationship>
    {
        public CustomerRelationshipValidator()
        {
        }
    }
}
