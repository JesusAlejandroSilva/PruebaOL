using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prueba.Domain.Entities;
using Prueba.Domain.Ports;
using Prueba.Infrastructure.Context;

namespace Prueba.Infrastructure.Adapters
{
    public class UserRepository : IUserRepository
    {
        private readonly PersistenceContext _context;

        public UserRepository(PersistenceContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> AddAsync(UserEntity user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserEntity?> GetByEmailAsync(string email)
        {
            if(email == null)
                throw new ArgumentNullException(nameof(email));

            return await _context.Users.FindAsync(email);
        }
    }
}
