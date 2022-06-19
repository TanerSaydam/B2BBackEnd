using Entities.Concrete;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHandler
    {
        Token CreateUserToken(User user, List<OperationClaim> operationClaims);
        Token CreateCustomerToken(Customer customer);
    }
}
