﻿using Microsoft.OpenApi.Models;
using TCCLions.API.Application.Services;
using TCCLions.Domain.Data.Repositories;
using TCCLions.Infrastructure.Data.Repositories;

namespace TCCLions.API;

public static class ProgramExtensions
{
    public static void InjectDependencies(this IServiceCollection service)
    {
        service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        service.AddScoped<IComissaoRepository, ComissaoRepository>();
        service.AddScoped<ITipoComissaoRepository, TipoComissaoRepository>();
        service.AddScoped<IPermissaoRepository, PermissaoRepository>();
        service.AddScoped<IMembroRepository, MembroRepository>();
        service.AddScoped<IPasswordHasher, PasswordHasher>();
        service.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
    }

    public static void ConfigureSwagger(this IServiceCollection service)
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
    }

    public static void ConfigureCors(this IServiceCollection service)
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
    }

}