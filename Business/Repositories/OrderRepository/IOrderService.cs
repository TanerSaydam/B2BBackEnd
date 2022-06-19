using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.OrderRepository
{
    public interface IOrderService
    {
        Task<IResult> Add(Order order);
        Task<IResult> Update(Order order);
        Task<IResult> Delete(Order order);
        Task<IDataResult<List<Order>>> GetList();
        Task<IDataResult<Order>> GetById(int id);
    }
}
