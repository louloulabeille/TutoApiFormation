using Microsoft.EntityFrameworkCore;
using TutoApiformation.Infrastructure.Database;
using TutoApiFormation.Applications.ExtendMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// - Add extends dbcontext
builder.Services.AddNpgsql(builder.Configuration);

// - Swagger lancement
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
