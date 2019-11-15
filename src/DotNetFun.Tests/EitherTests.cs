using System;
using FunBase.ClassInstances;
using Xunit;

namespace FunBase.Tests
{
    public class EitherTests
    {
        [Fact]
        public void EqualsTest()
        {
            var a = 2;
            var b = 2;
            var c = 3;
            var d = "test";
            var e = "test";
            Assert.Equal(Either<string,int>.Right(a), Either<string,int>.Right(b));
            Assert.Equal(Either<string,int>.Left(d), Either<string,int>.Left(e));
            Assert.NotEqual(Either<string, int>.Right(a), Either<string, int>.Right(c));
        }
        [Fact]
        public void Match()
        {
            String value = "value";
            int newValue = 42;
            var right = Either<int,String>.From(value);
            var left = Either<int,String>.From(newValue);
            Assert.Equal(newValue, right.Match(x => 0, x => newValue));
            Assert.Equal(0, left.Match(x => 0, x => newValue));
        }

        [Fact]
        public void MapRight()
        {
            int value = 42;
            String startValue = "value";
            var right = Either<bool,String>.From(startValue);
            Func<String, int> func = s => value;

            var actual = right.MapRight(func);
            var expected = Either<bool, int>.Right(value);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void MapLeft()
        {
            int value = 42;
            String startValue = "value";
            var left = Either<bool, String>.From(true);
            Func<bool, int> func = s => value;

            var actual = left.MapLeft(func);
            var expected = Either<int, String>.Left(value);

            Assert.Equal(expected, actual);
        }
    }
}
