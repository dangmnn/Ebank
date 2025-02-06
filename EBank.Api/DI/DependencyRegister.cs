using Autofac;
using EBank.Domain.Context;

namespace EBank.Api.DI
{
    public class DependencyRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EBankDbContext>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
