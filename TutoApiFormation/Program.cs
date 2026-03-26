using Microsoft.EntityFrameworkCore;
using TutoApiformation.Infrastructure.Database;
using TutoApiformation.Infrastructure.Repository;
using TutoApiformation.Interface.Repository;
using TutoApiFormation.Applications.ExtendMethods;
using TutoApiFormation.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// - Add extends dbcontext
builder.Services.AddNpgsql(builder.Configuration);

// - Swagger lancement
builder.Services.AddSwaggerGen();

// - Injection dépendance des Repository
builder.Services.AddRepository();

//- Injection WorkofUnit
builder.Services.AddUnitOfWork();

//- Injection MediaR mise en place
builder.Services.AddMediatRInject();

//- Ajout d'un filter au niveau de MediaR pour enlever le message au niveau de la licence dans le log
builder.Logging.AddFilterMediaRLogger();

//- Mise en place de la stratégie Identity pour sécuriser API avec JwtBearer
builder.Services.AddCustomIdentityUser();
builder.Services.AddDefaultAuthenticate(builder.Configuration);

//- Injection dépendance IOption<T> 
builder.Services.AddSecurityOptionsValue(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{   // possibilité de faire des tests comme dans un environnement de production en créant un tunnel qui 
    // va générer une url (création un tunnel de développement) puis lors de la sortie regarder l'onglet tunnel pour voir
    // l'url généré il est possible que l'url soit persistant 
    // https://learn.microsoft.com/fr-fr/shows/on-dotnet/testing-local-apis-on-device-with-dev-tunnels-and-dotnet-maui#time=03m30s

    app.MapOpenApi();
    // lancement du swagger
    app.UseSwagger();
    app.UseSwaggerUI(); // lien https://localhost:7259/swagger/index.html
}

if (app.Environment.IsProduction())
{   
    // lancement du swagger aussi pour la production, cela ne sert pas que pour les tests
    app.UseSwagger();
    app.UseSwaggerUI(); // lien https://localhost:7259/swagger/index.html
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
