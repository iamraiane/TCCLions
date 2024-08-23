using Autofac;
using MediatR;
using System.Reflection;
using TCCLions.API.Application.Behaviors;

namespace TCCLions.API.Infrastructure.Modules;

public class MediatorModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(this.GetType().GetTypeInfo().Assembly)
           .Where(t => t.Name.EndsWith("Validator"))
           .AsImplementedInterfaces()
           .InstancePerLifetimeScope();

        builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
    }
}
