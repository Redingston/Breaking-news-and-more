using System;
using Microsoft.AspNetCore.Identity;

namespace Application.UnitTests.Base.TestData
{
    public class RoleTestData
    {
        public static IdentityRole GetTestUserRole()
        {
            return new IdentityRole()
            {
                Id = "e8b06b9c-8b32-4816-b276-bd5e131d5ad10",
                Name = "authorizedUser",
                NormalizedName = "AUTHORIZEDUSER",
                ConcurrencyStamp = "e8b06b9c-8b32-4816-b276-bd5e131d5ad9"
            };
        }
    }
}