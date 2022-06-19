using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Repositories.PriceListDetailRepository
{
    public interface IPriceListDetailService
    {
        Task<IResult> Add(PriceListDetail priceListDetail);
        Task<IResult> Update(PriceListDetail priceListDetail);
        Task<IResult> Delete(PriceListDetail priceListDetail);
        Task<IDataResult<List<PriceListDetail>>> GetList();
        Task<List<PriceListDetail>> GetListByProductId(int productId);
        Task<IDataResult<PriceListDetail>> GetById(int id);
    }
}
