using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace TutoApiFormation.Applications.ExtendMethods
{
    public static class AddAuthorizeAllControllerExtend
    {
        extension (IServiceCollection services)
        {
            public IServiceCollection AddAuthorizeAllController()
            {
                services.AddControllers(options =>
                {
                    // -- création d'un policy
                    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

                    // -- ajout pour chaque controller du systeme d'authentification sur le controleur 
                    options.Filters.Add(new AuthorizeFilter(policy));
                });
                return services;
            }
        }
    }
}
