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
        extension (ILoggingBuilder logging)
        {
            public ILoggingBuilder AddFilterMediaRLogger()
            {
                return logging.AddFilter("LuckyPennySoftware.MediatR.License", LogLevel.None);
            }
        }
    }
}
