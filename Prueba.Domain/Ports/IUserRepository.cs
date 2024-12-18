using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prueba.Domain.Entities;

namespace Prueba.Domain.Ports
{
    public interface IUserRepository
    {
        Task<UserEntity?> GetByEmailAsync(string email);
        Task <UserEntity>AddAsync(UserEntity user);
        Task<IEnumerable<UserEntity>> GetAllAsync();
    }
}
