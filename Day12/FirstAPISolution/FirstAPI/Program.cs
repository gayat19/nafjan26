using FirstAPI.Contexts;
using FirstAPI.Interfaces;
using FirstAPI.Models;
using FirstAPI.Repositories;
using FirstAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Add JWT Bearer Authentication
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' followed by your token. Example: Bearer abc123"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
{
{
new OpenApiSecurityScheme
{
Reference = new OpenApiReference
{
Type = ReferenceType.SecurityScheme,
Id = "Bearer"
}
},
Array.Empty<string>()
}
});
});

#region Contexts
builder.Services.AddDbContext<ClinicContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Development"));
});
#endregion

#region CORS
builder.Services.AddCors(options =>
{
   options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
#endregion

#region Repositories
builder.Services.AddScoped<IRepository<int,Doctor>,Repository<int,Doctor>>();
builder.Services.AddScoped<IRepository<string,User>,Repository<string,User>>();
#endregion

#region Services
builder.Services.AddScoped<IDoctorService,DoctorServiceV1>();
builder.Services.AddScoped<IPasswordService,PasswordService>();
builder.Services.AddScoped<ITokenService,TokenService>();
builder.Services.AddScoped<IUserService,UserService>();
#endregion

#region Middlewares
string key = builder.Configuration["Keys:Jwt"] ?? throw new InvalidOperationException("Secret key not found in configuration.");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(option =>
    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
        ValidateIssuerSigningKey = true
    }
);

#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
