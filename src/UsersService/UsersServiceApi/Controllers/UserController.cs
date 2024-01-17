using AutoMapper;
using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersServiceApi.Application.Dtos;
using UsersServiceApi.Application.Interfaces.TokenService;
using UsersServiceApi.Application.Responses;
using UsersServiceApi.Infra.Repositories;
using BC = BCrypt.Net.BCrypt;

namespace UsersServiceApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController(IUserRepository userRepository, ITokenService tokenService, IMapper mapper) : ControllerBase
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly ITokenService _tokenService = tokenService;
        private readonly IMapper _mapper = mapper;


        [HttpPost]
        [Route("/Login")]
        public async Task<IActionResult> Login(UserLoginDto userLogin)
        {
            var exists = await _userRepository.UserExistsAsync(userLogin.Email);

            if(exists is null)
                return NotFound("The required user doesnt exists.");

            if (!BC.Verify(userLogin.Password, exists.HashedPassword))
                return BadRequest("Check the provided credentials.");

            var token = _tokenService.CreateToken(exists);

            var response = new LoginResponse()
            {
                Token = token,
                User = _mapper.Map<UserDto>(exists)
            };

            return Ok(response);
        }


        [HttpPost]
        [Route("/Register")]
        public async Task<IActionResult> Register(UserRegisterDto newUser)
        {
            var exists = await _userRepository.UserExistsAsync(newUser.Email);

            if (exists is not null)
                return BadRequest("Email already in use.");

            var hashedPassword = BC.HashPassword(newUser.Password);
            newUser.Password = hashedPassword;

            var createdUser = await _userRepository.CreateAsync(newUser);

            if (createdUser == null)
                return BadRequest("Error when creating user.");

            var saveResult = await _userRepository.SaveChangesAsync();

            if (!saveResult)
                return BadRequest("Error when creating user.");

            var token = _tokenService.CreateToken(createdUser);

            var response = new LoginResponse()
            {
                Token = token,
                User = _mapper.Map<UserDto>(createdUser)
            };

            return Ok(response);
        }
    }
}
