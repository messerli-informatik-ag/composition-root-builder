using System;
using Autofac;
using Autofac.Core;

namespace Messerli.CompositionRoot
{
    public sealed class CompositionRootBuilder
    {
        private readonly ContainerBuilder _builder = new();

        public CompositionRootBuilder RegisterModule<T>()
            where T : IModule, new()
        {
            _builder.RegisterModule<T>();
            return this;
        }

        public CompositionRootBuilder RegisterModule(IModule module)
            => Configure(builder => builder.RegisterModule(module));

        public CompositionRootBuilder Configure(Action<ContainerBuilder> configureAction)
        {
            configureAction(_builder);
            return this;
        }

        public IContainer Build()
            => _builder.Build();
    }
}
