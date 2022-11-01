using ApiNegozio.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Enabling Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
           builder =>
           {
               builder.WithOrigins(" * ").AllowAnyHeader().AllowAnyMethod();
           });

});
    

//add db context
builder.Services.AddDbContext<ProdottiNegozioContext>( options => options.UseSqlServer(builder.Configuration.GetConnectionString("negozioAppConn")));

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
