using Core.Repositorio;
using Core.Repositorio.Data;
using Core.Repositorio.Interfaces;
using Core.service;
using Core.service.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
InicializadorBD.Inicializar();
builder.Services.AddScoped<Icarroservice, carrinhoservice>();
builder.Services.AddScoped<ICarroRepositor, Carrinhorepositor>();
builder.Services.AddScoped<IVeiculoRepositor, VeiculoRepositor>();
builder.Services.AddScoped<Icaminhãorepositor, caminhãoRepositor>();
builder.Services.AddScoped<Icaminhãoservice, Caminãoservice>();
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
