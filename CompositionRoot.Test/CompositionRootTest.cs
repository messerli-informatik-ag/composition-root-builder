using Xunit;

namespace Messerli.CompositionRoot.Test
{
    public sealed class CompositionRootTest
    {
        [Fact]
        public void CompositionRootBuilds()
        {
            using (var container = new CompositionRoot().Build())
            {
                Assert.NotNull(container);
            }
        }
    }
}
