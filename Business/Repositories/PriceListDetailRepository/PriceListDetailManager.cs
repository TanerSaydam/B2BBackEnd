using Business.Aspects.Secured;
using Business.Repositories.PriceListDetailRepository.Constants;
using Business.Repositories.PriceListDetailRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.PriceListDetailRepository;
using Entities.Concrete;

namespace Business.Repositories.PriceListDetailRepository
{
    public class PriceListDetailManager : IPriceListDetailService
    {
        private readonly IPriceListDetailDal _priceListDetailDal;

        public PriceListDetailManager(IPriceListDetailDal priceListDetailDal)
        {
            _priceListDetailDal = priceListDetailDal;
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(PriceListDetailValidator))]
        [RemoveCacheAspect("IPriceListDetailService.Get")]

        public async Task<IResult> Add(PriceListDetail priceListDetail)
        {
            await _priceListDetailDal.Add(priceListDetail);
            return new SuccessResult(PriceListDetailMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(PriceListDetailValidator))]
        [RemoveCacheAspect("IPriceListDetailService.Get")]

        public async Task<IResult> Update(PriceListDetail priceListDetail)
        {
            await _priceListDetailDal.Update(priceListDetail);
            return new SuccessResult(PriceListDetailMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IPriceListDetailService.Get")]

        public async Task<IResult> Delete(PriceListDetail priceListDetail)
        {
            await _priceListDetailDal.Delete(priceListDetail);
            return new SuccessResult(PriceListDetailMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<PriceListDetail>>> GetList()
        {
            return new SuccessDataResult<List<PriceListDetail>>(await _priceListDetailDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<PriceListDetail>> GetById(int id)
        {
            return new SuccessDataResult<PriceListDetail>(await _priceListDetailDal.Get(p => p.Id == id));
        }

    }
}
