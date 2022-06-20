using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Repositories.BasketRepository
{
    public interface IBasketDal : IEntityRepository<Basket>
    {
        Task<List<BasketListDto>> GetListByCustomerId(int customerId);
    }
}
