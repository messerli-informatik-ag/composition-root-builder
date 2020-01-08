using System.Collections.Immutable;
using Autofac;

namespace Messerli.CompositionRoot
{
    public sealed class ModuleRegistrar : Module
    {
        private readonly ImmutableList<Register> _registrations;

        public ModuleRegistrar(ImmutableList<Register> mockRegistrations)
        {
            _registrations = mockRegistrations;
        }

        public delegate void Register(ContainerBuilder builder);

        protected override void Load(ContainerBuilder builder)
            => _registrations.ForEach(registration => registration(builder));
    }
}
