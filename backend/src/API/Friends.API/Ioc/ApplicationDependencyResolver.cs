using Friends.Domain.Repository.Inteface;
using Friends.Repository.Database.Context;
using Friends.Repository.Database.Repository;
using Friends.Repository.Database.Transaction;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Friends.API.Ioc
{
    public static class ApplicationDependencyResolver
    {
        public static void AddDependencies(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddDbContext<FriendsContext>(x => x.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                y => y.MigrationsHistoryTable("HistoryMigrations", "dataprovider")
            ));

            #region .: Transactions :.
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region .: Repository :.
            #endregion

            #region .: Services :.
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            #endregion
        }
    }
}
