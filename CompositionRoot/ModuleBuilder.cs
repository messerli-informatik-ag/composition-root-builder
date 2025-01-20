using System.Collections.Immutable;
using System.Diagnostics.Contracts;
using Autofac;
using Autofac.Core;

namespace Messerli.CompositionRoot;

public sealed class ModuleBuilder
{
    private readonly ImmutableList<Register> _registrations;

    public ModuleBuilder()
        => _registrations = ImmutableList<Register>.Empty;

    private ModuleBuilder(ImmutableList<Register> registrations)
        => _registrations = registrations;

    [Pure]
    public ModuleBuilder RegisterInstance<T>(T instance)
        where T : class
        => Register(builder => builder.RegisterInstance(instance));

    [Pure]
    public ModuleBuilder RegisterModule<TModule>()
        where TModule : IModule, new()
        => Register(builder => builder.RegisterModule<TModule>());

    [Pure]
    public ModuleBuilder RegisterModule<TModule>(TModule module)
        where TModule : IModule
        => Register(builder => builder.RegisterModule(module));

    [Pure]
    public ModuleBuilder Register(Register registrationFunction)
        => ShallowClone(_registrations.Add(registrationFunction));

    [Pure]
    public IModule Build()
        => new ModuleRegistrar(_registrations);

    private static ModuleBuilder ShallowClone(ImmutableList<Register> registrations) => new(registrations);
}
