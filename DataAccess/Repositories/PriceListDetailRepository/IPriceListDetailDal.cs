using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Repositories.PriceListDetailRepository
{
    public interface IPriceListDetailDal : IEntityRepository<PriceListDetail>
    {
        Task<List<PriceListDetailDto>> GetListDto(int priceListId);
    }
}
