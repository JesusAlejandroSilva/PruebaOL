using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prueba.Domain.Common.Dto;

namespace Prueba.Application.Interfaces
{
    public interface IUserServices
    {
        Task<UserDto> AuthenticateAsync(UserDto userDto);

       
    }
}
