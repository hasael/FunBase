using FunBase.Extensions;
using System.Threading.Tasks;
using Xunit;

namespace FunBase.Tests
{
    public class TaskTests
    {
        [Fact]
        public async Task FlatMap()
        {
            Task<int> t1 = Task<int>.Run(() =>
            {
                return 32;
            });

            var t2 = t1.FlatMap(_ => Task.FromResult(_ + 10));
            var actual = await t2;
            var expected = 42;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task Map()
        {
            Task<int> t1 = Task<int>.Run(() =>
            {
                return 32;
            });

            var t2 = t1.Map(_ => _ + 10);
            var actual = await t2;
            var expected = 42;
            Assert.Equal(expected, actual);

        }
    }
}
