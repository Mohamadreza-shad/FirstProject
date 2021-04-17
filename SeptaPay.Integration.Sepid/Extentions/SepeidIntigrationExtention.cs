using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SepidIntigration.Service;
using SeptaPay.Integration.Sepid.Contexts;
using SeptaPay.Integration.Sepid.Request;
using System;

namespace SeptaPay.Integration.Sepid.Extentions
{
    public static class SepeidIntigrationExtention
    {
        public static void AddSepeidIntigration(this IServiceCollection services, SepidOptions options)
        {

            services.AddDbContext<SepidContext>(m =>
            {
                m.UseSqlServer(options.ConnectionString);
            });



            services.Configure<SepidOptions>(x =>
            {

                x.ClientId = options.ClientId;
                x.ClientSecret = options.ClientSecret;
                x.ConnectionString = options.ConnectionString;
                x.PANFavaCode = options.PANFavaCode;
                x.SubSystemCode = options.SubSystemCode;
                x.SystemCode = options.SystemCode;
                
            });

            services.AddSingleton<SepidHttpClient>();

            services.AddScoped<ISepidService, SepidService>();

        }

    }
}