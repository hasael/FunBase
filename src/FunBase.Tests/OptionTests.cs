using FunBase.ClassInstances;
using System;
using Xunit;

namespace FunBase.Tests
{
    public class OptionTests
    {
        [Fact]
        public void EqualsTest()
        {
            var a = 2;
            var b = 2;
            var c = 3;
            Assert.Equal(Option<int>.From(a), Option<int>.From(b));
            Assert.Equal(Option<int>.None(), Option<int>.None());
            Assert.NotEqual(Option<int>.From(a), Option<int>.From(c));
        }

        [Fact]
        public void ConstructValue()
        {
            int value = 42;
            var sut = Option<int>.From(value);
            Assert.True(sut.IsDefined);
            Assert.False(sut.IsEmpty);
            Assert.Equal(sut.Get(), value);
        }

        [Fact]
        public void NoneValue()
        {
            String value = null;
            String @default = "default";
            var sut = Option<String>.From(value);
            Assert.False(sut.IsDefined);
            Assert.True(sut.IsEmpty);
            Assert.Throws<ArgumentNullException>(() =>sut.Get());
            Assert.Equal(sut.GetOrElse(@default), @default);
        }

        [Fact]
        public void GetOrElse()
        {
            String value = "value";
            String @default = "default"; 
            var sut = Option<String>.From(value);
            var none = Option<String>.None();
            var expected = Option<String>.From(@default);
            Assert.Equal(value, sut.Get());
            Assert.Equal(value,sut.GetOrElse(@default));
            Assert.Equal(value, sut.GetOrElse(() => @default));
            Assert.Equal(sut, sut.OrElse(() => Option<String>.From(@default)));
            Assert.Equal(@default, none.GetOrElse(@default));
            Assert.Equal(@default, none.GetOrElse(() => @default));
            Assert.Equal(expected, none.OrElse(() => Option<String>.From(@default)));
        }

        [Fact]
        public void Filter()
        {
            String value = "value";

            var sut = Option<String>.From(value);

            Assert.Equal(Option<String>.None(), sut.Filter(x => false));
            Assert.Equal(sut, sut.Filter(x => true));
        }

        [Fact]
        public void Exists()
        {
            String value = "value";

            var sut = Option<String>.From(value);

            Assert.False(sut.Exists(x => false));
            Assert.True(sut.Exists(x => true));
        }

        [Fact]
        public void Match()
        {
            String value = "value";
            int newValue = 42;
            var sut = Option<String>.From(value);
            var none = Option<object>.None();
            Assert.Equal(newValue, sut.Match(x => newValue, () => 0));
            Assert.Equal(0, none.Match(x => newValue, () => 0));
        }

        [Fact]
        public void Map()
        {
            int value = 42;
            String startValue = "value";
            var option = Option<String>.From(startValue);
            Func<String,int> func = s => value;

            var actual = option.Map(func);
            var expected = Option<int>.From(value);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FlatMap()
        {
            int value = 42;
            String startValue = "value";
            var option = Option<String>.From(startValue);
            Func<String, Option<int>> func = s => Option<int>.From(value);

            var actual = option.Map(func);
            var expected = Option<int>.From(value);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Apply()
        {
            int value = 42;
            String startValue = "value";
            var option = Option<String>.From(startValue);
            Func<String, int> func = s => value;

            var actual = option.Apply(Option<Func<string, int>>.Return(func));
            var expected = Option<int>.From(value);

            Assert.Equal(expected, actual);
        }
    }
}
