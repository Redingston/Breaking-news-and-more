using BreakingNewsCore.Entities.UserEntity;
using BreakingNewsCore.Interfaces.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class StartupSetup
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryGeneric<>), typeof(BaseRepository<>));
        }
        
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));
        }
        
        public static void AddIdentityDbContext(this IServiceCollection services)
        {
            services.AddIdentity<User,
                IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
        }
    }
}