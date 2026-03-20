namespace TutoApiFormation.Applications.ExtendMethods
{
    public static class AddMediatRExtend
    {
        extension (IServiceCollection services)
        {
            public IServiceCollection AddMediatRInject ()
            {
                return services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            }
        }
    }
}
