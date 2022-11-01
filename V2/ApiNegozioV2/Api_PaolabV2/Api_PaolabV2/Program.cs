
using Api_PaolabV2.Models;
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
builder.Services.AddDbContext<db_a8d5d1_negozioContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("negozioAppConn")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

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
