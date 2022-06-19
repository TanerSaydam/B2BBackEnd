using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.BasketRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.BasketRepository.Validation;
using Business.Repositories.BasketRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.BasketRepository;

namespace Business.Repositories.BasketRepository
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(BasketValidator))]
        [RemoveCacheAspect("IBasketService.Get")]

        public async Task<IResult> Add(Basket basket)
        {
            await _basketDal.Add(basket);
            return new SuccessResult(BasketMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(BasketValidator))]
        [RemoveCacheAspect("IBasketService.Get")]

        public async Task<IResult> Update(Basket basket)
        {
            await _basketDal.Update(basket);
            return new SuccessResult(BasketMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IBasketService.Get")]

        public async Task<IResult> Delete(Basket basket)
        {
            await _basketDal.Delete(basket);
            return new SuccessResult(BasketMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<Basket>>> GetList()
        {
            return new SuccessDataResult<List<Basket>>(await _basketDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<Basket>> GetById(int id)
        {
            return new SuccessDataResult<Basket>(await _basketDal.Get(p => p.Id == id));
        }

    }
}
