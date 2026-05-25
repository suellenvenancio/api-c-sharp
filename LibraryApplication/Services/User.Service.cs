using System.Security.Cryptography;
using LibraryApplication.DTO.User;
using LibraryApplication.Exceptions;
using LibraryApplication.Service.Interfaces;
using LibraryDomain.Account;
using LibraryDomain.Entities;
using LibraryDomain.Interfaces;

namespace LibraryApplication.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticate _authenticate;

        public UserService(IUserRepository userRepository, IAuthenticate authenticate)
        {
            _userRepository = userRepository;
            _authenticate = authenticate;
        }

        public async Task<UserGetDTO> GetUserById(Guid id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
                throw new NotFoundException($"User not found.");

            return new UserGetDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                CreatedAt = user.CreatedAt,
                Role = user.Role,
            };
        }

        public async Task<UserGetDTO> CreateUser(UserPostDTO userPostDTO)
        {
            if (await _authenticate.UserExists(userPostDTO.Email))
                throw new BadRequestException("Email is already in use.");
                
            using var hmac = new HMACSHA512();
            byte[] passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userPostDTO.Password));
            byte[] passwordSalt = hmac.Key;

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = userPostDTO.Name,
                Email = userPostDTO.Email,
                DateOfBirth = userPostDTO.DateOfBirth,
                PasswordSalt = passwordSalt,
                HashedPassword = passwordHash,
                CreatedAt = DateTime.UtcNow,
                Role = userPostDTO.Role,
            };

            await _userRepository.CreateUser(user);

            return new UserGetDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                CreatedAt = user.CreatedAt,
                Role = user.Role,
            };
        }

        public async Task<string> Login(string email, string password)
        {
            var isAuthenticated = await _authenticate.Authenticate(email, password);
            if (!isAuthenticated)
                throw new UnauthorizedException("Invalid email or password.");

            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
                throw new NotFoundException("User not found.");

            string token = _authenticate.GenerateToken(user.Id, user.Email);
          
            return token;
        }
       
    }
}