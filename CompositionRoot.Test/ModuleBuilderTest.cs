using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Messerli.CompositionRoot.Test.Stubs;
using Xunit;

namespace Messerli.CompositionRoot.Test
{
    public class ModuleBuilderTest
    {
        [Fact]
        public void CanBuildEmptyModule()
        {
            Assert.NotNull(new ModuleBuilder().Build());
        }

        [Fact]
        public void CreateModuleBuilderWithRegisteredModules()
        {
            using (var container = BuildModule(
                new ModuleBuilder()
                    .RegisterModule(new FooModule())
                    .RegisterModule<BarModule>()
                    .Build()))
            {
                Assert.NotNull(container.Resolve<IFoo>());
                Assert.NotNull(container.Resolve<IBar>());
            }
        }

        [Fact]
        public void CreateModuleBuilderWithRegisteredInstances()
        {
            using (var container = BuildModule(
                new ModuleBuilder()
                    .RegisterInstance(new Foo())
                    .RegisterInstance(new Bar())
                    .Build()))
            {
                Assert.NotNull(container.Resolve<Foo>());
                Assert.NotNull(container.Resolve<Bar>());
            }
        }

        [Fact]
        public void CreateModuleBuilderWithRegisteredRegistrationActions()
        {
            using (var container = BuildModule(
                new ModuleBuilder()
                    .Register(builder => builder.RegisterType<Foo>().As<IFoo>())
                    .Register(builder => builder.RegisterType<Bar>().As<IBar>())
                    .Build()))
            {
                Assert.NotNull(container.Resolve<IFoo>());
                Assert.NotNull(container.Resolve<IBar>());
            }
        }

        [Fact]
        public void ThrowsOnInstanceNotRegistered()
        {
            using (var container = BuildModule(
                new ModuleBuilder()
                .RegisterInstance(new Foo())
                .Build()))
            {
                Assert.NotNull(container.Resolve<Foo>());
                Assert.Throws<ComponentNotRegisteredException>(() => container.Resolve<IBar>());
            }
        }

        [Fact]
        public void ThrowsOnModuleNotRegistered()
        {
            using (var container = BuildModule(
                new ModuleBuilder()
                    .RegisterModule(new FooModule())
                    .Build()))
            {
                Assert.NotNull(container.Resolve<IFoo>());
                Assert.Throws<ComponentNotRegisteredException>(() => container.Resolve<IBar>());
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
