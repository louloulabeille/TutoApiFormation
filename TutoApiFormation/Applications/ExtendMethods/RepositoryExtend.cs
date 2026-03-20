using TutoApiformation.Infrastructure.Repository;
using TutoApiformation.Interface.Repository;
using TutoApiFormation.Domain.Infrastructure;

namespace TutoApiFormation.Applications.ExtendMethods
{
    public static class RepositoryExtend
    {
        extension (IServiceCollection services)
        {
            public IServiceCollection AddRepository ()
            {
                return services.AddScoped<IRepository<Categorie>, Repository<Categorie>>(); 
            }
        }

    }
}
