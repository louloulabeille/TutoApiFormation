using Microsoft.EntityFrameworkCore;
using TutoApiformation.Infrastructure.Database;
using TutoApiformation.Infrastructure.Repository;
using TutoApiformation.Interface.Repository;
using TutoApiFormation.Applications.ExtendMethods;
using TutoApiFormation.Domain.Infrastructure;

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

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // lancement du swagger
    app.UseSwagger();
    app.UseSwaggerUI(); // lien https://localhost:7259/swagger/index.html
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
