using Contracts;
using EntityFrameworkCore.UseRowNumberForPaging;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using NLog;
using Repository;
using Service;
using Service.Contracts;

namespace CompanyEmployeesv6.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
         services.AddCors(options =>
         {
             options.AddPolicy("CorsPolicy", builder =>
             builder.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());
         });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
         services.Configure<IISOptions>(options =>
         {
         });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<RepositoryContext>(opts =>
       
         opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        //opts.UseSqlServer("sqlConnection", i => i.UseRowNumberForPaging()));
        //opts.UseSqlServer("sqlConnection", builder => builder.UseRowNumberForPaging()));

        //public static void ConfigureSqlContext(this IServiceCollection services,
        //IConfiguration configuration) =>
        //services.AddSqlServer<RepositoryContext>((configuration.GetConnectionString("sqlConnection")));


        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
         services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();



    }
}
