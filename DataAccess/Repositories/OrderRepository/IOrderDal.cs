using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Repositories.OrderRepository
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        string GetOrderNumber();
        Task<List<OrderDto>> GetListDto();
        Task<List<OrderDto>> GetListByCustomerIdDto(int customerId);
        Task<OrderDto> GetByIdDto(int id);
    }
}
