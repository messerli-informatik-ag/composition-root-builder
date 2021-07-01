using Autofac;
using Autofac.Core;

namespace Messerli.CompositionRoot
{
    public sealed class CompositionRootBuilder
    {
        private readonly ContainerBuilder _builder = new ContainerBuilder();

        public CompositionRootBuilder RegisterModule<T>()
            where T : IModule, new()
        {
            _builder.RegisterModule<T>();
            return this;
        }

        public CompositionRootBuilder RegisterModule(IModule module)
        {
            _builder.RegisterModule(module);
            return this;
        }

        public IContainer Build()
            => _builder.Build();
    }
}
