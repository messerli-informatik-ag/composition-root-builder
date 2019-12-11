using Autofac;
using Autofac.Core;

namespace Messerli.CompositionRoot
{
    public sealed class CompositionRoot
    {
        private readonly ContainerBuilder _builder = new ContainerBuilder();

        public CompositionRoot RegisterModule<T>()
            where T : IModule, new()
        {
            _builder.RegisterModule<T>();
            return this;
        }

        public CompositionRoot RegisterModule(IModule module)
        {
            _builder.RegisterModule(module);
            return this;
        }

        public IContainer Build()
        {
            return _builder.Build();
        }
    }
}
