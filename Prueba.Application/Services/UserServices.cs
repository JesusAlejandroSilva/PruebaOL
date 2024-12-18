using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoMapper;
using Prueba.Application.Interfaces;
using Prueba.Domain.Common.Dto;
using Prueba.Domain.Entities;
using Prueba.Domain.Ports;

namespace Prueba.Application.Services
{
    public class UserServices:IUserServices
    {
       private readonly IUserRepository _userRepository;
       private readonly IMapper _mapper;
        public UserServices(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDto> AuthenticateAsync(UserDto userDto)
        {
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            var userEntity = _mapper.Map<UserEntity>(userDto);

            var create = await _userRepository.AddAsync(userEntity);

            return _mapper.Map<UserDto>(create);


        }

        public bool VerifyPassword(string password, string hash)
        {
            throw new NotImplementedException();
        }
    }
}
