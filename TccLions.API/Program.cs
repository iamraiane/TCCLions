using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using TCCLions.API;
using TCCLions.API.Infrastructure.Data;
using TCCLions.API.Infrastructure.Filters;
using TCCLions.API.Infrastructure.Modules;
using TCCLions.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();

var appConfigConnectionString = builder.Configuration.GetConnectionString("AppConfiguration");

if (!string.IsNullOrEmpty(appConfigConnectionString))
{
    builder.Configuration.AddAzureAppConfiguration(cfg =>
    {
        cfg.Connect(appConfigConnectionString)
        .Select(KeyFilter.Any, labelFilter: Environments.Production);
    });
}

builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpGlobalExceptionFilter>();
}).AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
        options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
    }); ;

builder.Services.InjectDependencies();

builder.Services.AddDbContext<ApplicationDataContext>(cfg => cfg.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddAuth(builder.Configuration);

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("Admin", policy => policy.RequireRole("Admin"));

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(_ => _.RegisterModule(new MediatorModule()));

builder.Services.ConfigureCors();

var app = builder.Build();

using (var Scope = app.Services.CreateScope())
{
    var context = Scope.ServiceProvider.GetRequiredService<ApplicationDataContext>();
    //context.Database.Migrate();
    ApplicationDataContextSeed.Seed(context);
}

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.UseHttpsRedirection();

app.Run();
