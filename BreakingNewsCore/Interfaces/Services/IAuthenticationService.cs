using System.Threading.Tasks;
using Application.DTO.UsersDTO;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<UserAutorizationDTO> LoginAsync(string email, string password);
        Task<UserAutorizationDTO> RefreshTokenAsync(UserAutorizationDTO userTokensDTO);
        Task LogoutAsync(UserAutorizationDTO userTokensDTO);
    }
}