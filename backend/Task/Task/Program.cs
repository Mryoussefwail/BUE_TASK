using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System;
using Task.Contexts;
using static System.Net.Mime.MediaTypeNames;
using Task.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(@"Data Source=DESKTOP-P4NA3MB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
           builder =>
           {
               builder.WithOrigins("http://localhost:3000") // Adjust this origin according to your React app's URL
                      .AllowAnyHeader()
                      .AllowAnyMethod();
           });
}
    );
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
app.UseCors();
app.UseCors("AllowReactApp");
app.Run();
