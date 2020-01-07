using System.Collections.Immutable;
using Autofac;

namespace Messerli.CompositionRoot
{
    public class ModuleRegistrar : Module
    {
        private readonly ImmutableList<Register> _mockRegistrations;

        public ModuleRegistrar(ImmutableList<Register> mockRegistrations)
        {
            _mockRegistrations = mockRegistrations;
        }

        public delegate void Register(ContainerBuilder builder);

        protected override void Load(ContainerBuilder builder)
        {
            foreach (var registration in _mockRegistrations)
            {
                registration(builder);
            }
        }
    }
}
