using BreakingNewsCore.Entities.UserEntity;

namespace Application.UnitTests.Base.TestData
{
    public class UserTestData
    {
        public static User GetTestUser()
        {
            return new User()
            {
                Id = "e8b06b9c-8b32-4816-b276-bd5e131d5ad4",
                Email = "test1@gmail.com",
                UserName = "Username1",
                PhoneNumber = "345522555"
            };
        }
    }
}