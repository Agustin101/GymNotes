using UsersServiceApi.Application.Dtos;

namespace UsersServiceApi.Application.Responses
{
    public class LoginResponse
    {
        public UserDto User { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
