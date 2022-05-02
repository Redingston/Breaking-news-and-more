using System.Threading;
using System.Threading.Tasks;
using Application.UnitTests.Base.TestData;
using BreakingNewsCore.Common.Models;
using BreakingNewsCore.Entities.UserEntity;
using BreakingNewsCore.Interfaces.Repositories;
using BreakingNewsCore.Users.Commands;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;

namespace Application.UnitTests.BLLApplication.Users.CommandsTests
{
    [TestFixture]
    public class CreateUserCommandTests
    {
        private readonly CreateUserCommand.CreateUserCommandHandler _sut;
        private readonly Mock<IUserRepository<User, string>> _mockContext = new Mock<IUserRepository<User, string>>();
        private readonly Mock<IUserRoleRepository<IdentityRole, string>> _mockIdentityRole = new Mock<IUserRoleRepository<IdentityRole, string>>();

        public CreateUserCommandTests()
        {
            _sut = new CreateUserCommand.CreateUserCommandHandler(_mockContext.Object, _mockIdentityRole.Object);
        }

        [Test]
        public async Task CreateUser_WithCorrectData_ReturnsResultSuccessAndUserId()
        {
            var request = new CreateUserCommand(){};
            var user = UserTestData.GetTestUser();
            var role = RoleTestData.GetTestUserRole();
            var pasword = "aDDSsdsads11!";
            request.Email = user.Email;
            request.Password = pasword;
            request.RoleName = role.Name;
            
            SetupCreateUserAsync(user, pasword);
            SetupFindUserRoleByNameAsync(role.Name);
            SetupAddToRoleAsync(user, role.Name);

            var result = await _sut.Handle(request, CancellationToken.None);

            result.Should().NotBeNull();
        }
        
        [TearDown]
        public void TearDown()
        {
            _mockContext.Verify();
        }

        protected void SetupCreateUserAsync(User user, string password)
        {
            _mockContext
                .Setup(x=>x.CreateUserAsync(user, password))
                .ReturnsAsync((Result.Success(), UserTestData.GetTestUser().Id))
                .Verifiable();
        }

        protected void SetupCreateUserRoleAsync(IdentityRole role, string name)
        {
            _mockIdentityRole
                .Setup(x=>x.CreateUserRoleAsync(new IdentityRole(name)))
                .ReturnsAsync((Result.Success(), RoleTestData.GetTestUserRole().Id))
                .Verifiable();
        }

        protected void SetupAddToRoleAsync(User user, string name)
        {
            _mockContext
                .Setup(x=>x.AddToRoleAsync(user, name))
                .ReturnsAsync(Result.Success)
                .Verifiable();
        }
        
        protected void SetupFindUserRoleByNameAsync(string name)
        {
            _mockIdentityRole
                .Setup(x=>x.FindUserRoleByNameAsync(name))
                .ReturnsAsync(RoleTestData.GetTestUserRole())
                .Verifiable();
        }
    }
}