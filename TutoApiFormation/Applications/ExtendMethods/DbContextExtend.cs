using Microsoft.EntityFrameworkCore;
using TutoApiformation.Infrastructure.Database;

namespace TutoApiFormation.Applications.ExtendMethods
{
    public static class DbContextExtend
    {
        extension(IServiceCollection services)
        {
            /// <summary>
            /// Methode d'extension pour ajouter la connexion à la base de données au niveau de l'api
            /// </summary>
            /// <param name="config"></param>
            /// <returns></returns>
            /// <exception cref="InvalidOperationException"></exception>
            public IServiceCollection AddNpgsql(IConfiguration config)
            {
                var connectionString = config.GetConnectionString("DefaultConnection")
                        ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

                services.AddDbContext<TutoApiDbContext>(options =>
                    options.UseNpgsql(connectionString)
                );
                return services;
            }
        } 
    }
}
