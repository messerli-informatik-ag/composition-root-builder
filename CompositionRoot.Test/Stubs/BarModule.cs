using Autofac;
using Messerli.CompositionRoot.Test.Stubs;

namespace Messerli.CompositionRoot.Test.Stubs
{
    internal sealed class BarModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Bar>().As<IBar>();
        }
    }
}
