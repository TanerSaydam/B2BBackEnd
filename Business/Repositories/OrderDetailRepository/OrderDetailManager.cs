using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.OrderDetailRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.OrderDetailRepository.Validation;
using Business.Repositories.OrderDetailRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.OrderDetailRepository;

namespace Business.Repositories.OrderDetailRepository
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(OrderDetailValidator))]
        [RemoveCacheAspect("IOrderDetailService.Get")]

        public async Task<IResult> Add(OrderDetail orderDetail)
        {
            await _orderDetailDal.Add(orderDetail);
            return new SuccessResult(OrderDetailMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(OrderDetailValidator))]
        [RemoveCacheAspect("IOrderDetailService.Get")]

        public async Task<IResult> Update(OrderDetail orderDetail)
        {
            await _orderDetailDal.Update(orderDetail);
            return new SuccessResult(OrderDetailMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IOrderDetailService.Get")]

        public async Task<IResult> Delete(OrderDetail orderDetail)
        {
            await _orderDetailDal.Delete(orderDetail);
            return new SuccessResult(OrderDetailMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<OrderDetail>>> GetList()
        {
            return new SuccessDataResult<List<OrderDetail>>(await _orderDetailDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<OrderDetail>> GetById(int id)
        {
            return new SuccessDataResult<OrderDetail>(await _orderDetailDal.Get(p => p.Id == id));
        }

    }
}
