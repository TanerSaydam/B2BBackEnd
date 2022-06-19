using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Repositories.CustomerRepository
{
    public interface ICustomerService
    {
        Task<IResult> Add(CustomerRegisterDto customerRegisterDto);
        Task<IResult> Update(Customer customer);
        Task<IResult> Delete(Customer customer);
        Task<IDataResult<List<Customer>>> GetList();
        Task<IDataResult<Customer>> GetById(int id);
        Task<Customer> GetByEmail(string email);
    }
}
