using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba.Application.Interfaces;
using Prueba.Application.Services;
using Prueba.Domain.Common.Dto;
using Prueba.Domain.Ports;

namespace Prueba.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly UserServices _userServices;

        public UsersController(UserServices userService)
        {
            _userServices = userService;
        }

        [HttpPost]
        public async Task<IActionResult> GetUsers(UserDto user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            var users = await _userServices.AuthenticateAsync(user);
            return Ok(users);
        }

    }
}
