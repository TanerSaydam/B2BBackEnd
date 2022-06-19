using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.PriceListRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.PriceListRepository
{
    public class EfPriceListDal : EfEntityRepositoryBase<PriceList, SimpleContextDb>, IPriceListDal
    {
    }
}
