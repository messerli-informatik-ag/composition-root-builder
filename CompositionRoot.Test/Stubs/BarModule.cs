using Autofac;

namespace Messerli.CompositionRoot.Test.Stubs;

internal sealed class BarModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Bar>().As<IBar>();
    }
}
