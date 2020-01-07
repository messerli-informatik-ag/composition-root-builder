using Autofac;

namespace Messerli.CompositionRoot.Test.Stubs
{
    internal sealed class FooModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Foo>().As<IFoo>();
        }
    }
}
