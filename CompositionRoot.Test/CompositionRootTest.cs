using Autofac;
using Autofac.Core.Registration;
using Messerli.CompositionRoot.Test.Stubs;
using Xunit;

namespace Messerli.CompositionRoot.Test;

public sealed class CompositionRootTest
{
    [Fact]
    public void CompositionRootBuilds()
    {
        using var container = new CompositionRootBuilder().Build();
        Assert.NotNull(container);
    }

    [Fact]
    public void CreateCompositionRootWithRegisteredModules()
    {
        using var container = new CompositionRootBuilder()
            .RegisterModule(new FooModule())
            .RegisterModule<BarModule>()
            .Build();
        Assert.NotNull(container.Resolve<IFoo>());
        Assert.NotNull(container.Resolve<IBar>());
    }

    [Fact]
    public void ThrowsOnComponentNotRegistered()
    {
        using var container = new CompositionRootBuilder()
            .RegisterModule(new FooModule())
            .Build();
        Assert.NotNull(container.Resolve<IFoo>());
        Assert.Throws<ComponentNotRegisteredException>(() => container.Resolve<IBar>());
    }
}
