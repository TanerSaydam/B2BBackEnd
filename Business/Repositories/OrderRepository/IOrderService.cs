using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Repositories.OrderRepository
{
    public interface IOrderService
    {
        Task<IResult> Add(int customerId);
        Task<IResult> Update(Order order);
        Task<IResult> Delete(Order order);
        Task<IDataResult<List<Order>>> GetList();
        Task<IDataResult<List<OrderDto>>> GetListDto();
        Task<IDataResult<List<OrderDto>>> GetListByCustomerIdDto(int customerId);
        Task<IDataResult<List<Order>>> GetListByCustomerId(int customerId);
        Task<IDataResult<Order>> GetById(int id);
        Task<IDataResult<OrderDto>> GetByIdDto(int id);
    }
}
