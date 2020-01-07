using System.Collections.Immutable;
using Autofac;
using Autofac.Core;

namespace Messerli.CompositionRoot
{
    public sealed class ModuleBuilder
    {
        private readonly IImmutableList<ModuleRegistrar.Register> _registrations;

        private ModuleBuilder(IImmutableList<ModuleRegistrar.Register> registrations)
        {
            _registrations = registrations;
        }

        public static ModuleBuilder Create()
            => new ModuleBuilder(ImmutableList<ModuleRegistrar.Register>.Empty);

        public ModuleBuilder RegisterInstance<T>(T instance)
            where T : class
            => Register(builder => builder.RegisterInstance(instance));

        public ModuleBuilder RegisterModule<TModule>()
            where TModule : IModule, new()
            => Register(builder => builder.RegisterModule<TModule>());

        public ModuleBuilder RegisterModule<TModule>(TModule module)
            where TModule : IModule
            => Register(builder => builder.RegisterModule(module));

        public ModuleBuilder Register(ModuleRegistrar.Register registrationFunction)
            => ShallowClone(_registrations.Add(registrationFunction));

        public IModule Build()
        {
            return new ModuleRegistrar(_registrations.ToImmutableList());
        }

        private static ModuleBuilder ShallowClone(IImmutableList<ModuleRegistrar.Register> registrations)
            => new ModuleBuilder(registrations);
    }
}
