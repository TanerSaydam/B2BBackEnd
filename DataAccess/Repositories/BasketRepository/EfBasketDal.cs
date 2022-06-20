using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.BasketRepository
{
    public class EfBasketDal : EfEntityRepositoryBase<Basket, SimpleContextDb>, IBasketDal
    {
        public async Task<List<BasketListDto>> GetListByCustomerId(int customerId)
        {
            using (var context = new SimpleContextDb())
            {
                var result = from basket in context.Baskets.Where(p => p.CustomerId == customerId)
                             join product in context.Products on basket.ProductId equals product.Id
                             select new BasketListDto
                             {
                                 Id = basket.Id,
                                 CustomerId = basket.CustomerId,
                                 ProductId = basket.ProductId,
                                 ProductName = product.Name,
                                 Price = basket.Price,
                                 Quantity = basket.Quantity,
                                 Total = basket.Price * basket.Quantity
                             };
                return await result.ToListAsync();
            }
        }
    }
}
