using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Repositories.OrderDetailRepository
{
    public interface IOrderDetailDal : IEntityRepository<OrderDetail>
    {
        Task<List<OrderDetailDto>> GetListDto(int orderId);
    }
}
