using FunBase.ClassInstances;
using System;
using Xunit;

namespace FunBase.Tests
{
    public class TryTests
    {
        [Fact]
        public void EqualsTest()
        {
            var a = 2;
            var b = 2;
            var c = 3;
            var d = new Exception("test");
            Assert.Equal(Try<int>.Success(a), Try<int>.Success(b));
            Assert.Equal(Try<int>.Fail(d), Try<int>.Fail(d));
            Assert.NotEqual(Try<int>.Success(a), Try<int>.Success(c));
        }

        [Fact]
        public void ConstructValue()
        {
            int value = 42;
            var sut = Try<int>.Success(value);
            Assert.True(sut.IsSuccess);
            Assert.False(sut.IsFailure);
            Assert.Equal(sut.Get(), value);
        }

        [Fact]
        public void ErrorValue()
        {
            var error = new ArgumentException("test");
            var sut = Try<String>.Fail(error);
            Assert.False(sut.IsSuccess);
            Assert.True(sut.IsFailure);
            Assert.Throws<ArgumentException>(() =>sut.Get());
          
        }

        [Fact]
        public void Recover()
        {
            const string value = "value";
            const string @default = "default";
            var error = new ArgumentException("test");
            var sut = Try<String>.Success(value);
            var fail = Try<String>.Fail(error);

            Assert.Equal(value, sut.Get());
            Assert.Equal(sut ,sut.Recover(e => @default));
            Assert.Equal(sut,sut.RecoverWith<string>(e => Try<string>.From(() => @default)));
            Assert.Throws<ArgumentException>(() => fail.Get());
            Assert.Equal(Try<string>.Success(@default), fail.Recover(e => @default));
            Assert.Equal( Try<string>.Success(@default), fail.RecoverWith<string>(e => Try<string>.From(() => @default)));
        }

        [Fact]
        public void GetOrElse()
        {
            const string value = "value";
            const string @default = "default";
            var error = new ArgumentException("test");
            var sut = Try<String>.Success(value);
            var fail = Try<String>.Fail(error);

            Assert.Equal(value, sut.Get());
            Assert.Equal( sut, sut.GetOrElse(() => @default));
            Assert.Equal( sut, sut.OrElse(() => Try<string>.From(() => @default)));
            Assert.Throws<ArgumentException>(() => fail.Get());
            Assert.Equal(Try<string>.Success(@default), fail.GetOrElse(() => @default));
            Assert.Equal(Try<string>.Success(@default), fail.OrElse(() => Try<string>.From(() => @default)));
        }


        [Fact]
        public void Match()
        {
            var value = "value";
            int newValue = 42;
            var sut = Try<string>.From(() => value);
            var none = Try<object>.Fail(new Exception());
            Assert.Equal(newValue, sut.Match(x => newValue, (e) => 0));
            Assert.Equal(0, none.Match(x => newValue, (e) => 0));
        }

        [Fact]
        public void Transform()
        {
            var value = "value";
            int newValue = 42;
            var sut = Try<string>.From(() => value);
            var none = Try<object>.Fail(new Exception());
            Assert.Equal( Try<int>.Success(newValue), sut.Transform(x => Try<int>.From(() => newValue), (e) =>Try<int>.Success(0)));
            Assert.Equal(Try<int>.Success(0), none.Transform(x => Try<int>.From(() => newValue), (e) => Try<int>.Success(0)));
        }

        [Fact]
        public void Map()
        {
            int value = 42;
            var startValue = "value";
            var option = Try<String>.From(() => startValue);
            Func<String,int> func = s => value;

            var actual = option.Map(func);
            var expected = Try<int>.From(() => value);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FlatMap()
        {
            int value = 42;
            String startValue = "value";
            var tryApp = Try<String>.From(() => startValue);
            Func<String, Try<int>> func = s => Try<int>.From(() => value);

            var actual = tryApp.FlatMap(func);
            var expected = Try<int>.From(() => value);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Apply()
        {
            int value = 42;
            String startValue = "value";
            var tryApp = Try<String>.From(() => startValue);
            Func<String, int> func = s => value;

            var actual = tryApp.Apply(Try<Func<string, int>>.From(() => func));
            var expected = Try<int>.From(() => value);

            Assert.Equal(expected, actual);
        }
    }
}
