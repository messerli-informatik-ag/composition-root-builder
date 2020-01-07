using Xunit;

namespace Messerli.CompositionRoot.Test
{
    public sealed class CompositionRootTest
    {
        [Fact]
        public void CompositionRootBuilds()
        {
            using (var container = new CompositionRootBuilder().RegisterModule(ModuleBuilder.Create().Build()).Build())
            {
                Assert.NotNull(container);
            }
        }
    }
}
