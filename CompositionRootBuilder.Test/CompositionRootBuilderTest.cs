using Xunit;

namespace Messerli.CompositionRootBuilder.Test
{
    public sealed class CompositionRootBuilderTest
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
