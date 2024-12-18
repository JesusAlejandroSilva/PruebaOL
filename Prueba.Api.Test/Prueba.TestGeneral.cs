using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Moq;
using Prueba.Application.Services;
using Prueba.Domain.Entities;
using Prueba.Domain.Ports;

namespace Prueba.Api.Test
{
    public class Prueba
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        //private readonly Mock<IJwtProvider> _jwtProviderMock;
        private readonly UserServices _authService;
        private Mock<IMapper> _mapperMock;

        public Prueba()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _mapperMock = new Mock<IMapper>();
            _authService = new UserServices(_userRepositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task AuthenticateAsync_ReturnsToken_WhenCredentialsAreValid()
        {
            // Arrange
            var email = "test@example.com";
            var password = "password";
            var hashedPassword = password; // Simulando que coinciden para simplificar
            var user = new UserEntity { Email = email, PasswordHash = hashedPassword };

            _userRepositoryMock.Setup(repo => repo.GetByEmailAsync(email))
                .ReturnsAsync(user);

            _jwtProviderMock.Setup(provider => provider.GenerateToken(user))
                .Returns("test_token");

            // Act
            var token = await _authService.AuthenticateAsync(email, password);

            // Assert
            Assert.NotNull(token);
  
        }

        [Test]
        public async Task AuthenticateAsync_ReturnsNull_WhenCredentialsAreInvalid()
        {
            // Arrange
            var email = "test@example.com";
            var password = "wrong_password";

            _userRepositoryMock.Setup(repo => repo.GetByEmailAsync(email))
                .ReturnsAsync((UserEntity?)null);

            // Act
            var token = await _authService.A(email, password);

            // Assert
            Assert.Null(token);
        }
        
    }
}
