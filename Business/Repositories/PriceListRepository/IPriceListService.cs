using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.PriceListRepository
{
    public interface IPriceListService
    {
        Task<IResult> Add(PriceList priceList);
        Task<IResult> Update(PriceList priceList);
        Task<IResult> Delete(PriceList priceList);
        Task<IDataResult<List<PriceList>>> GetList();
        Task<IDataResult<PriceList>> GetById(int id);
    }
}
