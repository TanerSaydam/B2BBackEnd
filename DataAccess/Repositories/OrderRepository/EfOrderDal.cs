using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Repositories.OrderRepository
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, SimpleContextDb>, IOrderDal
    {
        public string GetOrderNumber()
        {
            using (var context = new SimpleContextDb())
            {
                var findLastOrder = context.Orders.OrderByDescending(p => p.Id).LastOrDefault();

                if (findLastOrder == null)
                {
                    return "SP00000000000001";
                }

                string findLastOrderNumber = findLastOrder.OrderNumber;
                findLastOrderNumber = findLastOrderNumber.Substring(2, 14);
                int orderNumberInt = Convert.ToInt16(findLastOrderNumber);
                orderNumberInt++;
                string newOrderNumber = orderNumberInt.ToString();

                for (int i = newOrderNumber.Length; i < 14; i++)
                {
                    newOrderNumber = "0" + newOrderNumber;
                }

                newOrderNumber = "SP" + newOrderNumber;
                return newOrderNumber;
            }
        }
    }
}
