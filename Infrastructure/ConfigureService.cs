using Application.Common.Interfaces;
using Domain.Repositories;
using Infrastructure.Os;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ConfigureServices;

    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ApplicationDbContext>(Options => Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDateTimeProvider();
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            services.AddScoped<ICommonService, CommonService>();

            services.AddTransient<IDateTime, DateTimeService>();
        return services;
        }
    }

