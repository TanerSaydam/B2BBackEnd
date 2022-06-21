using Entities.Concrete;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHandler
    {
        AdminToken CreateUserToken(User user, List<OperationClaim> operationClaims);
        CustomerToken CreateCustomerToken(Customer customer);
    }
}
