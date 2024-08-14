using CdbDomain.Repository.Interface;
using CdbDomain.Service;
using CdbDomain.Service.Interfaces;
using CdbInfra.Context;
using CdbInfra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string connectionString = builder.Configuration.GetConnectionString("CnnStr");

builder.Services.AddDbContext<CdbContext>(
                options => options.UseSqlServer(connectionString)); 

//Services
builder.Services.AddTransient<IInvestimentoService, InvestimentoService>();
//Infra
builder.Services.AddTransient<IInvestimentoRepository, InvestimentoRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllCalculoCdb",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200") // Substitua pelo endereço da sua aplicação Angular
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllCalculoCdb");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
