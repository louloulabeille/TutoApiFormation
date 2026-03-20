using TutoApiformation.Infrastructure;
using TutoApiformation.Interface.UnitOfWork;

namespace TutoApiFormation.Applications.ExtendMethods
{
    public static class UnitOfWorkExtend
    {
        extension (IServiceCollection services )
        {
            public IServiceCollection AddUnitOfWork()
            {
                return services.AddScoped<IUnitOfWork,UnitOfWork>();
            }
        }
    }
}
