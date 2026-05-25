using LibraryDomain.Entities;
using LibraryDomain.Interfaces;
using LibraryInfraData.Context;
using Microsoft.EntityFrameworkCore;

namespace LibraryInfraData.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            _context.User.Add(user);
             await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.User.FirstOrDefaultAsync(user => user.Email.ToLower() == email.ToLower());
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _context.User.FindAsync(id);
        }

        Task IUserRepository.CreateUser(User user)
        {
            return CreateUser(user);
        }
    }
}