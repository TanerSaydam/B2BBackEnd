using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.CustomerRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.CustomerRepository
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, SimpleContextDb>, ICustomerDal
    {
    }
}
