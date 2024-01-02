using ITicket.Application.Services;
using ITicket.Domain.Repositories;
using ITicket.Infra.Data;
using ITicket.Infra.Factory;
using ITicket.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure DbContext for PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("YourDbConnectionString");
builder.Services.AddDbContext<YourDbContext>(options => options.UseNpgsql(connectionString));

// Register repositories and services
builder.Services.AddScoped<IEventEfRepository, EventEfRepository>();
builder.Services.AddScoped<IEventRepositoryFactory, EventRepositoryFactory>();
// Remova o registro do EventService aqui

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
