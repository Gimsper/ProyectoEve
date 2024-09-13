using Autofac.Core;
using Eve.Core.Context;
using Eve.Infraestructure.Base;
using Eve.Infraestructure.Base.Interfaces;
using Eve.Infraestructure.Repositories;
using Eve.Infraestructure.Repositories.Interfaces;
using Eve.Infraestructure.Services;
using Eve.Infraestructure.Services.Interfaces;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<EveContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<_IBaseRepository, _BaseRepository>();
builder.Services.AddScoped<_IBaseService, _BaseService>();
builder.Services.AddScoped<IUserLoginRepository, UserLoginRepository>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();

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
