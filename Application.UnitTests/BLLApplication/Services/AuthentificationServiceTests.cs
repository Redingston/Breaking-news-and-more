using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.UnitTests.Base;
using Application.UnitTests.Base.TestData;
using Ardalis.Specification;
using BreakingNewsCore.Common.Exceptions;
using BreakingNewsCore.DTO.UsersDTO;
using BreakingNewsCore.Entities.RefreshTokenEntity;
using BreakingNewsCore.Entities.UserEntity;
using BreakingNewsCore.Interfaces.Repositories;
using BreakingNewsCore.Interfaces.Services;
using BreakingNewsCore.Services;
using BreakingNewsCore.Common;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;

namespace Application.UnitTests.BLLApplication.Services
{
    [TestFixture]
    public class AuthentificationServiceTests
    {
        protected AuthenticationService _authentificationService;
        
        protected Mock<UserManager<User>> _userManagerMock;
        protected Mock<SignInManager<User>> _signInManagerMock;
        protected Mock<IJwtService> _jwtServiceMock;
        protected Mock<RoleManager<IdentityRole>> _roleManagerMock;
        protected Mock<IRepositoryGeneric<RefreshToken>> _refreshTokenRepositoryMock;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _userManagerMock = UserManagerMock.GetUserManager<User>();
            _signInManagerMock = SignInManagerMock.GetSignInManager<User>();
            _roleManagerMock = RoleManagerMock.GetRoleManager<IdentityRole>();

            _jwtServiceMock = new Mock<IJwtService>();
            _refreshTokenRepositoryMock = new Mock<IRepositoryGeneric<RefreshToken>>();


            _authentificationService = new AuthenticationService(
                _userManagerMock.Object,
                _signInManagerMock.Object,
                _jwtServiceMock.Object,
                _roleManagerMock.Object,
                _refreshTokenRepositoryMock.Object);
        }

        [Test]
        public async Task LoginAsync_UserNotExist_ThrowException()
        {
            var user = UserTestData.GetTestUser();
            
            SetupFindByEmailAsync(user.Email, null);
            
            Func<Task<UserAutorizationDTO>> act = () =>
                _authentificationService.LoginAsync(user.Email, null);

            await act.Should()
                .ThrowAsync<HttpException>()
                .Where(x => x.StatusCode == HttpStatusCode.Unauthorized)
                .WithMessage(Constants.INCORECT_EMAIL_PASSWORD);
        }

        [Test]
        public async Task LoginAsync_CorrectEmail_ReturnUserAuthorizationDTO()
        {
            var claims = GetClaims();
            var user = UserTestData.GetTestUser();
            var userPassword = "Password_1";
            var expectedUserAutorizationDTO = GetUserAutorizationDTO();

            SetupFindByEmailAsync(user.Email, user);
            SetupCheckPasswordAsync(user, userPassword);
            SetupSetClaims(user, claims);
            SetupCreateToken(claims, "token");
            SetupCreateRefreshToken("refreshToken");

            var result = await _authentificationService.LoginAsync(user.Email, userPassword);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedUserAutorizationDTO);
        }

        [Test]
        public async Task RefreshTokenAsync_RefreshTokenNull_ThrowsException()
        {
            var user = UserTestData.GetTestUser();
            var userAuthDTO = GetUserAutorizationDTO();
            RefreshToken refreshToken = null;
            
            SetupGetFirstBySpecAsync(refreshToken);
            Func<Task<UserAutorizationDTO>> act = () =>
                _authentificationService.RefreshTokenAsync(userAuthDTO);

            await act.Should()
                .ThrowAsync<HttpException>()
                .Where(x => x.StatusCode == HttpStatusCode.BadRequest)
                .WithMessage(Constants.INVALID_TOKEN);
        }

        [Test]
        public async Task RefreshTokenAsync_RTValid_ReturnsUserAuthDTO()
        {
            var user = UserTestData.GetTestUser();
            var userDTO = GetUserAutorizationDTO();
            var claims = GetClaims();
            var tokenId = user.Id;
            var token = "token";
            var refreshTokenName = "refreshToken";
            var expiredRefreshToken = new RefreshToken();
            RefreshToken refreshToken = new RefreshToken()
            {
                Id = tokenId,
                UserId = user.Id,
                User = user,
                Token = refreshTokenName
            };
            
            SetupGetFirstBySpecAsync(expiredRefreshToken);
            SetupGetClaimsFromExpiredToken(token, claims);
            SetupCreateToken(claims, token);
            SetupCreateRefreshToken(refreshToken.Token);
            SetupUpdateAsync(expiredRefreshToken);
            SetupSaveChangesAsync();

            var result = await _authentificationService.RefreshTokenAsync(userDTO);
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(userDTO);
        }

        [Test]
        public async Task LogoutAsync_RefreshTokenNull_RefreshTokenInNull()
        {
            var userAutorizationDTO = GetUserAutorizationDTO();
            
            SetupGetFirstBySpecAsync(null);

            var result = Task.Run(async () =>
                await _authentificationService.LogoutAsync(userAutorizationDTO));
            result.Wait();

            result.IsCompleted.Should().BeTrue();
            result.IsCompletedSuccessfully.Should().BeTrue();
        }
        
        [Test]
        public void LogoutAsync_RefreshTokenNotNull_RefreshTokenDeleted()
        {
            var userMock = UserTestData.GetTestUser();
            var userAutorizationDTO = GetUserAutorizationDTO();
            var refreshToken = GetRefreshToken();

            SetupGetFirstBySpecAsync(refreshToken);
            SetupDeleteAsync(refreshToken);
            SetupSaveChangesAsync();

            var result = Task.Run(() =>
                _authentificationService.LogoutAsync(userAutorizationDTO));
            result.Wait();

            result.IsCompleted.Should().BeTrue();
            result.IsCompletedSuccessfully.Should().BeTrue();
        }
        
        [TearDown]
        public void TearDown()
        {
            _userManagerMock.Verify();
            _signInManagerMock.Verify();
            _jwtServiceMock.Verify();
            _roleManagerMock.Verify();
            _refreshTokenRepositoryMock.Verify();
        }

        protected void SetupCreateToken(string token)
        {
            _jwtServiceMock
                .Setup(x => x.CreateToken(It.IsAny<IEnumerable<Claim>>()))
                .Returns(token)
                .Verifiable();
        }

        protected void SetupSetClaimsAsync(IEnumerable<Claim> claims)
        {
            _jwtServiceMock
                .Setup(x => x.SetClaims(It.IsAny<User>()))
                .Returns(claims)
                .Verifiable();
        }

        protected void SetupAddLoginAsync()
        {
            _userManagerMock
                .Setup(x => x.AddLoginAsync(It.IsAny<User>(), It.IsAny<UserLoginInfo>()))
                .ReturnsAsync(IdentityResult.Success)
                .Verifiable();
        }

        protected void SetupFindByEmailAsync(string email, User userInstance)
        {
            _userManagerMock
                .Setup(x => x.FindByEmailAsync(email ?? It.IsAny<string>()))
                .ReturnsAsync(userInstance)
                .Verifiable();
        }

        protected void SetupCheckPasswordAsync(User user, string password)
        {
            _userManagerMock
                .Setup(x => x.CheckPasswordAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(true)
                .Verifiable();
        }

        protected void SetupSetClaims(User user, IEnumerable<Claim> claims)
        {
            _jwtServiceMock
                .Setup(x => x.SetClaims(It.IsAny<User>()))
                .Returns(claims)
                .Verifiable();
        }

        protected void SetupCreateToken(IEnumerable<Claim> claims, string token)
        {
            _jwtServiceMock
                .Setup(x => x.CreateToken(It.IsAny<IEnumerable<Claim>>()))
                .Returns(token)
                .Verifiable();
        }

        protected void SetupCreateRefreshToken(string refreshToken)
        {
            _jwtServiceMock
               .Setup(x => x.CreateRefreshToken())
               .Returns(refreshToken)
               .Verifiable();
        }

        protected void SetupVerifyTwoFactorTokenAsync(User user,
            string tokenProvider,
            string token,
            bool result)
        {
            _userManagerMock
               .Setup(x => x.VerifyTwoFactorTokenAsync(user ?? It.IsAny<User>(),
                    tokenProvider ?? It.IsAny<string>(),
                    token ?? It.IsAny<string>()))
               .ReturnsAsync(result)
               .Verifiable();
        }

        protected void SetupGetFirstBySpecAsync(RefreshToken refreshToken)
        {
            _refreshTokenRepositoryMock
                .Setup(x => x.GetFirstBySpecAsync(It.IsAny<ISpecification<RefreshToken>>()))
                .ReturnsAsync(refreshToken)
                .Verifiable();
        }


        protected void SetupGetClaimsFromExpiredToken(string token, IEnumerable<Claim> claims)
        {
            _jwtServiceMock
                .Setup(x => x.GetClaimsFromExpiredToken(token ?? It.IsAny<string>()))
                .Returns(claims)
                .Verifiable();
        }

        protected void SetupSaveChangesAsync()
        {
            _refreshTokenRepositoryMock
                .Setup(x => x.SaveChangesAsync())
                .ReturnsAsync(1)
                .Verifiable();
        }

        protected void SetupUpdateAsync(RefreshToken refreshToken)
        {
            _refreshTokenRepositoryMock
                .Setup(x => x.UpdateAsync(refreshToken))
                .Verifiable();
        }

        protected void SetupDeleteAsync(RefreshToken refreshToken)
        {
            _refreshTokenRepositoryMock
                .Setup(x => x.DeleteAsync(refreshToken))
                .Verifiable();
        }

        protected void SetupGeneratePasswordResetTokenAsync(User user, string token)
        {
            _userManagerMock
                .Setup(x => x.GeneratePasswordResetTokenAsync(user ?? It.IsAny<User>()))
                .ReturnsAsync(token)
                .Verifiable();
        }

        protected void SetupResetPasswordAsync(User user,
            string decodedCode,
            string newPassword,
            IdentityResult result)
        {
            _userManagerMock
                .Setup(x => x.ResetPasswordAsync(user, decodedCode, newPassword))
                .ReturnsAsync(result)
                .Verifiable();
        }

        protected void SetupCreateAsync(User user, string password, IdentityResult result)
        {
            _userManagerMock
                .Setup(x => x.CreateAsync(user, password))
                .ReturnsAsync(result)
                .Verifiable();
        }

        protected void SetupFindByNameAsync(string roleName, IdentityRole role)
        {
            _roleManagerMock
                .Setup(x => x.FindByNameAsync(roleName))
                .ReturnsAsync(role)
                .Verifiable();
        }

        protected void SetupCreateAsync(IdentityRole role, IdentityResult result)
        {
            _roleManagerMock
                .Setup(x => x.CreateAsync(It.IsAny<IdentityRole>()))
                .ReturnsAsync(result)
                .Verifiable();
        }

        protected void SetupAddToRoleAsync(User user, string role, IdentityResult result)
        {
            _userManagerMock
                .Setup(x => x.AddToRoleAsync(user, role))
                .ReturnsAsync(result)
                .Verifiable();
        }

        public IEnumerable<Claim> GetClaims()
        {
            return new List<Claim>
            {
                new Claim("1","2"),
                new Claim("3","4")
            };
        }

        public List<User> GetTestUserList()
        {
            return new List<User>()
            {
                new User()
                {
                    Id = "Wfef234ferf-sddfs1",
                    Email = "test1@gmail.com",
                    UserName = "Username1",
                    PhoneNumber = "3343243424"
                },

                new User()
                {
                    Id = "Wfef234ferf-sddfs2",
                    Email = "test2@gmail.com",
                    UserName = "Username2",
                    PhoneNumber = "34343243"
                }
            };
        }

        private RefreshToken GetRefreshToken()
        {
            return new RefreshToken()
            {
                Id = "Wfef234ferf-sddfs2",
                UserId = "Wfef234ferf344-4-34",
                User = new User(),
                Token = "refreshToken"
            };
        }

        protected UserAutorizationDTO GetUserAutorizationDTO()
        {
            return new UserAutorizationDTO()
            {
                Token = "token",
                RefreshToken = "refreshToken"
            };
        }

        public List<Claim> GetClaimList()
        {
            return new List<Claim>()
            {
                new Claim("type", "value") {}
            };
        }
    }
}