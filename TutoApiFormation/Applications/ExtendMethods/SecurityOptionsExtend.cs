using TutoApiformation.Infrastructure.Configuration;

namespace TutoApiFormation.Applications.ExtendMethods
{
    /// <summary>
    /// injection de dépendance de la classe des options de sécurités
    /// IOptions<SecurityJwtBearer>
    /// </summary>
    public static class SecurityOptionsExtend
    {
        extension(IServiceCollection services)
        {
            public IServiceCollection AddSecurityOptionsValue(IConfiguration config)
            {
                services.Configure<SecurityJwtBearer>(config.GetSection("JwtBearerOptions"));
                return services;
            }
        }
    }
}
