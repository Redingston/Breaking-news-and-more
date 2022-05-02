using System.Linq;
using BreakingNewsCore.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace BreakingNewsCore.Helpers
{
    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }
    }
}