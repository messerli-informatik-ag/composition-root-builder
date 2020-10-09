using System.Collections.Immutable;
using Autofac;

namespace Messerli.CompositionRoot
{
    public delegate void Register(ContainerBuilder builder);

    internal sealed class ModuleRegistrar : Module
    {
        private readonly ImmutableList<Register> _registrations;

        public ModuleRegistrar(ImmutableList<Register> mockRegistrations)
        {
            _registrations = mockRegistrations;
        }

        protected override void Load(ContainerBuilder builder)
            => _registrations.ForEach(registration => registration(builder));
    }
}
