using System.Collections.Immutable;
using Autofac;
using Autofac.Core;

namespace Messerli.CompositionRoot
{
    public sealed class ModuleBuilder
    {
        private readonly ImmutableList<ModuleRegistrar.Register> _registrations;

        public ModuleBuilder()
        {
            _registrations = ImmutableList<ModuleRegistrar.Register>.Empty;
        }

        private ModuleBuilder(ImmutableList<ModuleRegistrar.Register> registrations)
        {
            _registrations = registrations;
        }

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
            => new ModuleRegistrar(_registrations);

        private static ModuleBuilder ShallowClone(ImmutableList<ModuleRegistrar.Register> registrations)
            => new ModuleBuilder(registrations);
    }
}
