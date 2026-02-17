using FirstAPI.Contexts;
using FirstAPI.Interfaces;
using FirstAPI.Models;
using FirstAPI.Repositories;
using FirstAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ClinicContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Development"));
});

builder.Services.AddScoped<IRepository<int,Doctor>,Repository<int,Doctor>>();
builder.Services.AddScoped<IRepository<string,User>,Repository<string,User>>();

builder.Services.AddScoped<IDoctorService,DoctorService>();
builder.Services.AddScoped<IPasswordService,PasswordService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
