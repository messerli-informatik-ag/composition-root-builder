using Autofac;
using Autofac.Core;
using Messerli.CompositionRoot.Test.Stubs;
using Xunit;

namespace Messerli.CompositionRoot.Test
{
    public class ModuleBuilderTest
    {
        [Fact]
        public void EmptyModuleBuilds()
        {
            Assert.NotNull(ModuleBuilder.Create().Build());
        }

        [Fact]
        public void ModuleBuildsWithRegisteredModules()
        {
            using (var container = BuildModule(
                ModuleBuilder.Create()
                    .RegisterModule(new FooModule())
                    .RegisterModule<BarModule>()
                    .Build()))
            {
                Assert.NotNull(container.Resolve<IFoo>());
                Assert.NotNull(container.Resolve<IBar>());
            }
        }

        [Fact]
        public void ModuleBuildsWithRegisteredInstance()
        {
            using (var container = BuildModule(
                ModuleBuilder.Create()
                    .RegisterInstance(new Foo())
                    .RegisterInstance(new Bar())
                    .Build()))
            {
                Assert.NotNull(container.Resolve<Foo>());
                Assert.NotNull(container.Resolve<Bar>());
            }
        }

        [Fact]
        public void ModuleBuildsWithRegisteredRegistrationActions()
        {
            using (var container = BuildModule(
                ModuleBuilder.Create()
                    .Register(builder => builder.RegisterType<Foo>().As<IFoo>())
                    .Register(builder => builder.RegisterType<Bar>().As<IBar>())
                    .Build()))
            {
                Assert.NotNull(container.Resolve<IFoo>());
                Assert.NotNull(container.Resolve<IBar>());
            }
        }

        private static IContainer BuildModule(IModule module)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);

            return builder.Build();
        }
    }
}
