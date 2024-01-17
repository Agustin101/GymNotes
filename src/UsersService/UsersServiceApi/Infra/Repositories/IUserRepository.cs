using UsersServiceApi.Application.Dtos;
using UsersServiceApi.Domain.Models;

namespace UsersServiceApi.Infra.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(UserRegisterDto user);
        Task<bool> SaveChangesAsync();
        Task<User?> UserExistsAsync(string userEmail);
    }
}
