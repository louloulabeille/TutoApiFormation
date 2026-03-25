using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TutoApiformation.Infrastructure.Configuration;
using TutoApiformation.Infrastructure.Database;

namespace TutoApiFormation.Applications.ExtendMethods
{
    public static class LoginExtend
    {
        extension(IServiceCollection services)
        {
            /// <summary>
            /// Mise en place du parémétrage par défaut de IdentityUser
            /// </summary>
            /// <returns></returns>
            public IServiceCollection AddCustomIdentityUser()
            {
                services.AddDefaultIdentity<IdentityUser>(options =>
                {
                    // options du password lors de la création 
                    // 12 caractères minimuns - au moins un chiffre -
                    // au moins un caractère spécial - au moins une majuscule et minuscule
                    options.Password = new PasswordOptions()
                    {
                        RequiredLength = 12,
                        RequireDigit = true,
                        RequireNonAlphanumeric = true,
                        RequireLowercase = true,
                        RequireUppercase = true,
                        RequiredUniqueChars = 1
                    };

                    // option sur le login
                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    options.User.RequireUniqueEmail = true;

                    // option sur la répétition de tentative de connexion sur un compte
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                    options.Lockout.MaxFailedAccessAttempts = 3;

                    // - a mettre en place après
                    //options.SignIn.RequireConfirmedEmail = true;
                    //options.SignIn.RequireConfirmedAccount = true;

                }).AddEntityFrameworkStores<TutoApiDbContext>();

                return services;
            }

            /// <summary>
            /// Mise en place de la stratégie de authenticate de JwtBearer
            /// avec les différentes options - le système est un tokken de connexion 
            /// </summary>
            /// <returns></returns>
            public IServiceCollection AddDefaultAuthenticate (IConfiguration config)
            {
                // récupération des informations des options des JwtBearer
                SecurityJwtBearer? jwtBearer = new();
                config.GetSection("JwtBearerOptions").Bind(jwtBearer);

                // récuparation de la clé de chiffrenement
                services.AddAuthentication(options => 
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                
                }).AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false, // - je n'ai qu'une APi pour le momment, pas besoin de gestion de back et front 
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateActor = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtBearer.Issuer,
                        //ValidAudience = "your_audience",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtBearer.Key!))
                    };
                });

                return services;
            }
        }
    }
}
