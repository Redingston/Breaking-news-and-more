using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using System;
using System.Collections.Generic;
using BreakingNewsCore;
using BreakingNewsCore.Entities.NewsEntity;
using BreakingNewsCore.Entities.TagEntity;
using BreakingNewsCore.Entities.UserEntity;
using BreakingNewsCore.Helpers;
using BreakingNewsCore.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using BreakingNewsCore.Interfaces.Repositories;
using BreakingNewsCore.Interfaces.Services;
using BreakingNewsCore.Services;
using Infrastructure;
using WebUI.ServiceExtension;

namespace WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddCustomServices();
            services.AddHttpContextAccessor();
            services.AddJwtAuthentication(Configuration);
            var assembly = AppDomain.CurrentDomain.Load("BreakingNewsCore");
          //  services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
         
            services.AddMediatR(assembly);

            // services.AddTransient<INotifierMediatorService, NotifierMediatorService>();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                                           options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            )
                    ;
           
            services.AddDbContext(Configuration.GetConnectionString("BNAMDataBase"));
            services.AddIdentityDbContext();

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer",
                                        new OpenApiSecurityScheme
                                        {
                                            Description = "JWT Authorization header using the Bearer scheme.",
                                            Type = SecuritySchemeType.Http,
                                            Scheme = "bearer"
                                        });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                                  builder => builder
                                             .AllowAnyOrigin()
                                             .AllowAnyMethod()
                                             .AllowAnyHeader()
                                             .Build());
            });

            services.AddScoped<IRepository<News, string>, NewsRepository>();
            services.AddScoped<IRepository<Tag, string>, TagRepository>();
            services.AddScoped<IUserRepository<User, string>, UserRepository>();
            services.AddScoped<IUserRoleRepository<IdentityRole, string>, UserRoleRepository>();
           // services.AddScoped<IRepository<RefreshToken, string>, RefreshTokenRepository>();
           
            services.Configure<JwtOptions>(Configuration);
            services.AddAutoMapper();
            services.AddRepositories();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.Migrate();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BNAM API V1");
            });

            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
