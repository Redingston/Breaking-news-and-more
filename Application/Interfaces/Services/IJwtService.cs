using System.Collections.Generic;
using System.Security.Claims;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IJwtService
    {
        IEnumerable<Claim> SetClaims(User user);
        string CreateToken(IEnumerable<Claim> claims);
        string CreateRefreshToken();
        IEnumerable<Claim> GetClaimsFromExpiredToken(string token);
    }
}