using ExamenTI.DataAccess;
using ExamenTI.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using ExamenTI.Infrastructure.Configurations;
using ExamenTI.Business.Interfaces;
using ExamenTI.Business.Services;
using ExamenTI.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Conección a la bd
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services to the container.
// Agregar los repositorios
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//Agregamos los servicios
builder.Services.AddScoped<IClientServices, ClientServices>();
builder.Services.AddScoped<IStoreServices, StoreServices>();
builder.Services.AddScoped<IArticleServices, ArticleServices>();
builder.Services.AddScoped<IUserServices, UserServices>();

//Agregar el perfil del AutoMapper
builder.Services.AddAutoMapper(typeof(Mapping));

/*Login*/
var key = builder.Configuration.GetValue<string>("ApiSettings:KeySecret");
builder.Services.AddAuthentication(x =>
{
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

/*Documentación de Swagger*/
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
        "Authentication whit JWT used schema Bearer. \r\n\r\n" +
        "Enter the letter 'Bearer' followed by a [space] and then your token in the input above. \r\n\r\n" +
        "Example: \"Bearer eyeabc123example123\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

builder.Services.AddSwaggerGen();

//configuración de cors 
builder.Services.AddCors(c => c.AddPolicy("PolicyCors", build => build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()));

//configuración de caché a futuro
builder.Services.AddResponseCaching();

builder.Services.AddControllers(option =>
{
    option.CacheProfiles.Add("Default20seconds", new CacheProfile
    {
        Duration = 30
    });
});

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
