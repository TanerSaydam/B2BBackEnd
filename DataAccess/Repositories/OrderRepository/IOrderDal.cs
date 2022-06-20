using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Repositories.OrderRepository
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        string GetOrderNumber();
    }
}
