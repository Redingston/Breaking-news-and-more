using System.Threading.Tasks;
using BreakingNewsCore.DTO.UsersDTO;

namespace BreakingNewsCore.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<UserAutorizationDTO> LoginAsync(string email, string password);
        Task<UserAutorizationDTO> RefreshTokenAsync(UserAutorizationDTO userTokensDTO);
        Task LogoutAsync(UserAutorizationDTO userTokensDTO);
    }
}