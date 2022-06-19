using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.CustomerRelationshipRepository
{
    public interface ICustomerRelationshipService
    {
        Task<IResult> Add(CustomerRelationship customerRelationship);
        Task<IResult> Update(CustomerRelationship customerRelationship);
        Task<IResult> Delete(CustomerRelationship customerRelationship);
        Task<IDataResult<List<CustomerRelationship>>> GetList();
        Task<IDataResult<CustomerRelationship>> GetById(int id);
    }
}
