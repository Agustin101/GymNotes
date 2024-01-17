using UsersServiceApi.Domain.Models;

namespace UsersServiceApi.Application.Interfaces.TokenService
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
