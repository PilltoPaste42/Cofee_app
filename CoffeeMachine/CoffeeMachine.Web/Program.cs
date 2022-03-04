using System.Data.Entity.Core;

using CoffeeMachine.Infrastructure;
using CoffeeMachine.Infrastructure.Data;
using CoffeeMachine.Infrastructure.Extensions;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresDb"));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddUnitOfWorkAndRepositories();

var app = builder.Build();

app.InitDb();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAppExceptionHandler();

app.MapControllers();

app.Run();