using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.BasketRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.BasketRepository
{
    public class EfBasketDal : EfEntityRepositoryBase<Basket, SimpleContextDb>, IBasketDal
    {
    }
}
