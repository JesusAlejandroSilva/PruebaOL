using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Prueba.Domain.Common.Dto;
using Prueba.Domain.Entities;

namespace Prueba.Application.Configurations.Mapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<UserEntity, UserDto>()
                .ReverseMap();

            CreateMap<TaskEntity, TaskDto>()
                .ReverseMap();
        }
    }
}
