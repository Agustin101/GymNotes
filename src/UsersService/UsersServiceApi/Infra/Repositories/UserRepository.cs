using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UsersServiceApi.Application.Dtos;
using UsersServiceApi.Domain.Models;
using UsersServiceApi.Infra.Data;

namespace UsersServiceApi.Infra.Repositories
{
    public class UserRepository(UsersDbContext dbContext, IMapper mapper) : IUserRepository
    {
        private readonly UsersDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<User> CreateAsync(UserRegisterDto userRegister)
        {
            var user = _mapper.Map<User>(userRegister);
            var createdUser = await _dbContext.Users.AddAsync(user);
            return createdUser.Entity;
        }

        public async Task<bool> SaveChangesAsync()
        {
           return await _dbContext.SaveChangesAsync() > 0;    
        }

        public async Task<User?> UserExistsAsync(string userEmail)
        {
            var exists = await _dbContext.Users.AnyAsync(u => u.Email == userEmail);

            if (!exists)
                return null;

            return await _dbContext.Users.FirstAsync(user => user.Email == userEmail);
        }
    }
}
