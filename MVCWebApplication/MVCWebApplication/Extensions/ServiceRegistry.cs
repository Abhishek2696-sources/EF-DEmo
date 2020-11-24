using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVCWebApplication.DAL.Context;
using MVCWebApplication.DAL.EmployeeDAL;
using MVCWebApplication.DAL.EmployeeDAL.Interface;
using MVCWebApplication.DAL.Interface;
using MVCWebApplication.Query.Generic;

namespace MVCWebApplication.Extensions
{
    public static class ServiceRegistry
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmployee, Employee>();
            services.AddScoped<IEmployees, EmployeeDB>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("DBConnection")));
            services.AddScoped<IDapperWrapper, DapperWrapper>();

        }
    }
}
