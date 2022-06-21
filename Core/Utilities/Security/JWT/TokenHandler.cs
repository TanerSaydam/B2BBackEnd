using Core.Extensions;
using Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class TokenHandler : ITokenHandler
    {
        IConfiguration Configuration;

        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public AdminToken CreateUserToken(User user, List<OperationClaim> operationClaims)
        {
            AdminToken token = new AdminToken();

            //Security Key'in simetriğini alalım
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));

            //Şifrelenmiş kimliği oluşturuyoruz
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //Token ayarlarını yapıyoruz
            token.Expiration = DateTime.Now.AddMinutes(60);
            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: Configuration["Token:Issuer"],
                audience: Configuration["Token:Audience"],
                expires: token.Expiration,
                claims: SetClaims(user, operationClaims),
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials
                );

            //Token oluşturucu sınıfından bir örnek alalım
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            //Token üretelim
            token.AdminAccessToken = jwtSecurityTokenHandler.WriteToken(securityToken);

            //Refresh token üretelim
            token.RefreshToken = CreateRefreshToken();
            return token;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddId(user.Id.ToString());
            claims.AddName(user.Name);
            claims.AddRoles(operationClaims.Select(p => p.Name).ToArray());
            return claims;
        }

        public CustomerToken CreateCustomerToken(Customer customer)
        {
            CustomerToken token = new CustomerToken();

            //Security Key'in simetriğini alalım
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));

            //Şifrelenmiş kimliği oluşturuyoruz
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //Token ayarlarını yapıyoruz
            token.Expiration = DateTime.Now.AddMinutes(60);
            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: Configuration["Token:Issuer"],
                audience: Configuration["Token:Audience"],
                expires: token.Expiration,
                claims: SetCustomerClaims(customer),
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials
                );

            //Token oluşturucu sınıfından bir örnek alalım
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            //Token üretelim
            token.CustomerAccessToken = jwtSecurityTokenHandler.WriteToken(securityToken);

            //Refresh token üretelim
            token.RefreshToken = CreateRefreshToken();
            return token;
        }

        private IEnumerable<Claim> SetCustomerClaims(Customer customer)
        {
            var claims = new List<Claim>();
            claims.AddId(customer.Id.ToString());
            claims.AddName(customer.Name);
            return claims;
        }
    }
}
