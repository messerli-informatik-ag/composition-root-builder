using Xunit;

namespace Messerli.CompositionRoot.Test
{
    public sealed class CompositionRootTest
    {
        [Fact]
        public void CompositionRootBuilds()
        {
            using (var container = new CompositionRootBuilder().Build())
            {
                Assert.NotNull(container);
            }
        }
    }
}
