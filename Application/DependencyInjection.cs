﻿using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
           // services.AddAutomaper(Assembly.GetExecutingAssembly());
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
           // services.AddMediatrR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}