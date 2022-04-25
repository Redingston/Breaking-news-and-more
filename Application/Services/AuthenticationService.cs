using System.Threading;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.DTO.UsersDTO;

namespace Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        protected readonly UserManager<User> _userManager;
        protected readonly SignInManager<User> _signInManager;
        protected readonly IJwtService _jwtService;
        protected readonly RoleManager<IdentityRole> _roleManager;
        protected readonly IRepository<RefreshToken, string> _refreshTokenRepository;

        public AuthenticationService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IJwtService jwtService,
            RoleManager<IdentityRole> roleManager,
            IRepository<RefreshToken, string> refreshTokenRepository)
           
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
            _roleManager = roleManager;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<UserAutorizationDTO> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, password))
            {
                throw new HttpException(System.Net.HttpStatusCode.Unauthorized,"Incorrect Login or Password");
            }

            return await GenerateUserTokens(user);
        }

        private async Task<UserAutorizationDTO> GenerateUserTokens(User user)
        {
            var claims = _jwtService.SetClaims(user);

            var token = _jwtService.CreateToken(claims);
            var refeshToken = await CreateRefreshToken(user);

            var tokens = new UserAutorizationDTO()
            {
                Token = token,
                RefreshToken = refeshToken
            };

            return tokens;
        }

        private async Task<string> CreateRefreshToken(User user)
        {
            var refeshToken = _jwtService.CreateRefreshToken();

            RefreshToken rt = new()
            {
                Token = refeshToken,
                UserId = user.Id
            };

            await _refreshTokenRepository.Insert(rt);
            await _refreshTokenRepository.SaveChangesAsync(CancellationToken.None);

            return refeshToken;
        }

        public Task LogoutAsync(UserAutorizationDTO userTokensDTO)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserAutorizationDTO> RefreshTokenAsync(UserAutorizationDTO userTokensDTO)
        {
            throw new System.NotImplementedException();
        }

        public Task RegistrationAsync(User user, string password, string roleName)
        {
            throw new System.NotImplementedException();
        }
    }
}