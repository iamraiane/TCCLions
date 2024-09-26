using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TCCLions.API.Application.Services;
using TCCLions.Domain.Data.Repositories;
using TCCLions.Infrastructure.Data.Repositories;

namespace TCCLions.API;

public static class ProgramExtensions
{
    public static IServiceCollection InjectDependencies(this IServiceCollection service)
    {
        service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        service.AddScoped(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));
        service.AddScoped<IComissaoRepository, ComissaoRepository>();
        service.AddScoped<IPermissaoRepository, PermissaoRepository>();
        service.AddScoped<IMembroRepository, MembroRepository>();
        service.AddScoped<IPasswordHasher, PasswordHasher>();
        service.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        return service;
    }

    public static IServiceCollection ConfigureSwagger(this IServiceCollection service)
    {
        service.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "TCCLions API", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Autorize usando o esquema Bearer. \r\n\r\n " +
                              "Digite 'Bearer' [espaço] e então seu token na entrada de texto abaixo.\r\n\r\n" +
                              "Exemplo: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
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
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });
        });

        return service;
    }

    public static IServiceCollection ConfigureCors(this IServiceCollection service)
    {
        service.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });

        return service;
    }

    public static IServiceCollection AddAuth(this IServiceCollection service, IConfiguration configuration) {

        service.AddAuthentication(cfg =>
        {
            cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(cfg =>
        {
            cfg.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]))
            };
        });

        return service;
    }

}
