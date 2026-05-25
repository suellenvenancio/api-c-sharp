using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using LibraryDomain.Account;
using LibraryDomain.Entities;
using LibraryDomain.Interfaces;
using LibraryInfraData.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LibraryInfraData.Authenticate
{
    public class AuthenticateService : IAuthenticate
    {
        
       private readonly ApplicationDbContext _context;
       private readonly IConfiguration _configuration;
       private readonly IUserRepository _userRepository;
        public AuthenticateService(ApplicationDbContext context, IConfiguration configuration, IUserRepository userRepository)
        {
            _context = context;
            _configuration = configuration;
            _userRepository = userRepository;
        }
        public string GenerateToken(Guid id, string email)
        {
            var claims = new[]
            {
                new  Claim("id", id.ToString()),
                new  Claim("email", email.ToLower()),
                new  Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<Boolean> Authenticate(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
                return false;
            
            using var hmac = new HMACSHA512(user.PasswordSalt);
            byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.HashedPassword[i])
                    return false;
            }
            return true;
        }

        public async Task<bool> UserExists(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            return user != null;   
        }
    }
    
}