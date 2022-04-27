using System;
using System.Text;
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
                Id = Guid.NewGuid().ToString(),
                Token = refeshToken,
                UserId = user.Id
            };

            await _refreshTokenRepository.Insert(rt);
            await _refreshTokenRepository.SaveChangesAsync(CancellationToken.None);

            return refeshToken;
        }

        public async Task LogoutAsync(UserAutorizationDTO userTokensDTO)
        {
            var refeshTokenFromDb = await _refreshTokenRepository.GetByIdAsync(userTokensDTO.Token);

            if (refeshTokenFromDb == null)
            {
                return;
            }

            _refreshTokenRepository.Delete(refeshTokenFromDb);
            await _refreshTokenRepository.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<UserAutorizationDTO> RefreshTokenAsync(UserAutorizationDTO userTokensDTO)
        {
            var specification = new RefreshTokens.SearchRefreshToken(userTokensDTO.RefreshToken);
            var refeshTokenFromDb = await _refreshTokenRepository.GetFirstBySpecAsync(specification);

            if (refeshTokenFromDb == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, "InvalidToken");
            }

            var claims = _jwtService.GetClaimsFromExpiredToken(userTokensDTO.Token);
            var newToken = _jwtService.CreateToken(claims);
            var newRefreshToken = _jwtService.CreateRefreshToken();

            refeshTokenFromDb.Token = newRefreshToken;
            _refreshTokenRepository.Update(refeshTokenFromDb);
            await _refreshTokenRepository.SaveChangesAsync(CancellationToken.None);

            var tokens = new UserAutorizationDTO()
            {
                Token = newToken,
                RefreshToken = newRefreshToken
            };

            return tokens;
        }
    }
}