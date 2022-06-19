using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.OrderDetailRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.OrderDetailRepository
{
    public class EfOrderDetailDal : EfEntityRepositoryBase<OrderDetail, SimpleContextDb>, IOrderDetailDal
    {
    }
}
