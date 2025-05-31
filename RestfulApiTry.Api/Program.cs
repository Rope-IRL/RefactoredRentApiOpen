using Microsoft.EntityFrameworkCore;
using RestfulApiTry.Api.ExceptionHandlers;
using RestfulApiTry.Persistence.Repositories;
using RestFulApiTry.Application.Interfaces.Services;
using RestFulApiTry.Application.Services;
using RestfulApiTry.Core.Repositories;
using RestfulApiTry.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

builder.Services.AddDbContext<RentDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlConnection")));

builder.Services.AddScoped<ILandlordRepository, LandlordRepository>();
builder.Services.AddScoped<ILandlordService, LandlordService>();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
