using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TCCLions.API.Infrastructure.Filters;
using TCCLions.API.Infrastructure.Modules;
using TCCLions.Domain.Data.Repositories;
using TCCLions.Infrastructure.Data;
using TCCLions.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpGlobalExceptionFilter>();
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddScoped<IComissaoRepository, ComissaoRepository>();
builder.Services.AddScoped<ITipoComissaoRepository, TipoComissaoRepository>();
builder.Services.AddScoped<IMembroRepository, MembroRepository>();

builder.Services.AddDbContext<ApplicationDataContext>(cfg => cfg.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(_ => _.RegisterModule(new MediatorModule()));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

using (var Scope = app.Services.CreateScope())
{
    var context = Scope.ServiceProvider.GetRequiredService<ApplicationDataContext>();
    context.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseCors();

app.UseHttpsRedirection();

app.Run();
