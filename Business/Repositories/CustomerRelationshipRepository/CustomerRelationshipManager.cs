using Business.Aspects.Secured;
using Business.Repositories.CustomerRelationshipRepository.Constants;
using Business.Repositories.CustomerRelationshipRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.CustomerRelationshipRepository;
using Entities.Concrete;

namespace Business.Repositories.CustomerRelationshipRepository
{
    public class CustomerRelationshipManager : ICustomerRelationshipService
    {
        private readonly ICustomerRelationshipDal _customerRelationshipDal;

        public CustomerRelationshipManager(ICustomerRelationshipDal customerRelationshipDal)
        {
            _customerRelationshipDal = customerRelationshipDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(CustomerRelationshipValidator))]
        [RemoveCacheAspect("ICustomerRelationshipService.Get")]

        public async Task<IResult> Add(CustomerRelationship customerRelationship)
        {
            await _customerRelationshipDal.Add(customerRelationship);
            return new SuccessResult(CustomerRelationshipMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(CustomerRelationshipValidator))]
        [RemoveCacheAspect("ICustomerRelationshipService.Get")]
        [RemoveCacheAspect("ICustomerService.Get")]

        public async Task<IResult> Update(CustomerRelationship customerRelationship)
        {
            var result = await _customerRelationshipDal.Get(p => p.CustomerId == customerRelationship.CustomerId);
            if (result != null)
            {
                customerRelationship.Id = result.Id;
                await _customerRelationshipDal.Update(customerRelationship);
            }
            else
            {
                await _customerRelationshipDal.Add(customerRelationship);
            }

            return new SuccessResult(CustomerRelationshipMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("ICustomerRelationshipService.Get")]

        public async Task<IResult> Delete(CustomerRelationship customerRelationship)
        {
            await _customerRelationshipDal.Delete(customerRelationship);
            return new SuccessResult(CustomerRelationshipMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<CustomerRelationship>>> GetList()
        {
            return new SuccessDataResult<List<CustomerRelationship>>(await _customerRelationshipDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<CustomerRelationship>> GetById(int id)
        {
            return new SuccessDataResult<CustomerRelationship>(await _customerRelationshipDal.Get(p => p.Id == id));
        }

        [SecuredAspect()]
        public async Task<IDataResult<CustomerRelationship>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<CustomerRelationship>(await _customerRelationshipDal.Get(p => p.CustomerId == customerId));
        }

    }
}
