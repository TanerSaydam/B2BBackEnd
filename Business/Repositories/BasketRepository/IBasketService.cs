using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.BasketRepository
{
    public interface IBasketService
    {
        Task<IResult> Add(Basket basket);
        Task<IResult> Update(Basket basket);
        Task<IResult> Delete(Basket basket);
        Task<IDataResult<List<Basket>>> GetList();
        Task<IDataResult<Basket>> GetById(int id);
    }
}
