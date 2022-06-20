using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Repositories.OrderDetailRepository
{
    public interface IOrderDetailService
    {
        Task<IResult> Add(OrderDetail orderDetail);
        Task<IResult> Update(OrderDetail orderDetail);
        Task<IResult> Delete(OrderDetail orderDetail);
        Task<IDataResult<List<OrderDetail>>> GetList(int orderId);
        Task<List<OrderDetail>> GetListByProductId(int productId);
        Task<IDataResult<OrderDetail>> GetById(int id);
    }
}
