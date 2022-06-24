using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Repositories.CustomerRepository
{
    public interface ICustomerService
    {
        Task<IResult> Add(CustomerRegisterDto customerRegisterDto);
        Task<IResult> Update(Customer customer);
        Task<IResult> ChangePasswordByAdminPanel(CustomerChangePassworByAdminPanelDto customerDto);
        Task<IResult> Delete(Customer customer);
        Task<IDataResult<List<CustomerDto>>> GetList();
        Task<IDataResult<Customer>> GetById(int id);
        Task<IDataResult<CustomerDto>> GetDtoById(int id);
        Task<Customer> GetByEmail(string email);
    }
}
