using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Repositories.OrderRepository
{
    public interface IOrderService
    {
        Task<IResult> Add(int customerId);
        Task<IResult> Update(Order order);
        Task<IResult> Delete(Order order);
        Task<IDataResult<List<Order>>> GetList();
        Task<IDataResult<Order>> GetById(int id);
    }
}
