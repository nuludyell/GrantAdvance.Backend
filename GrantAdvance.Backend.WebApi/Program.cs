using GrantAdvance.Backend.Application;
using GrantAdvance.Backend.Infrastructure;
using GrantAdvance.Backend.WebApi.Extensions;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

CorsExtensions.AddCorsAlllowedOrigins(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseRouting();

app.UseCors(builder.Configuration["CORS:PolicyName"] ?? "");

app.UseAuthorization();

app.UseCustomExceptionHandler();

app.MapControllers();

app.Run();
