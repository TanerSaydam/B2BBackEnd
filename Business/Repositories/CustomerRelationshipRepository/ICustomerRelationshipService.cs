using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Repositories.CustomerRelationshipRepository
{
    public interface ICustomerRelationshipService
    {
        Task<IResult> Add(CustomerRelationship customerRelationship);
        Task<IResult> Update(CustomerRelationship customerRelationship);
        Task<IResult> Delete(CustomerRelationship customerRelationship);
        Task<IDataResult<List<CustomerRelationship>>> GetList();
        Task<IDataResult<CustomerRelationship>> GetById(int id);
        Task<IDataResult<CustomerRelationship>> GetByCustomerId(int customerId);
    }
}
