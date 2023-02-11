using CRUD.Api.Configurations;
using CRUD.Application.Interfaces;
using CRUD.Application.Services;
using CRUD.Data;
using CRUD.Data.Repositories;
using CRUD.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var connectionString = builder.Configuration.GetConnectionString("Empregado");
builder.Services.AddDbContext<FactoryContext>(o => o.UseSqlServer(connectionString));
builder.Services.AddScoped<IEmpregadoRepository, EmpregadoRepository>();
builder.Services.AddScoped<IEmpregadoService, EmpregadoService>();



builder.Services.AddControllers();
builder.Services.AddAutoMapperConfig();
//builder.Services.AddDependencyInjectionConfig();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
