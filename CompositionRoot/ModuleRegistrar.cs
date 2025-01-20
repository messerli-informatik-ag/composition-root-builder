using System.Collections.Immutable;
using Autofac;

namespace Messerli.CompositionRoot;

public delegate void Register(ContainerBuilder builder);

internal sealed class ModuleRegistrar(ImmutableList<Register> mockRegistrations) : Module
{
    protected override void Load(ContainerBuilder builder)
        => mockRegistrations.ForEach(registration => registration(builder));
}
