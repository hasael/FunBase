using FunBase.Types;
using System;
using System.Diagnostics.Contracts;

namespace FunBase.ClassInstances
{
    public class Try<A>
    {
        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;
        protected readonly Exception Error;
        protected readonly A Value;
        protected Try(Exception error)
        {
            IsFailure = true;
            Error = error;
        }

        protected Try(A value)
        {
            IsFailure = false;
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj?.GetHashCode() == this.GetHashCode();
        }

        public override int GetHashCode()
        {
            if (IsSuccess)
                return Value?.GetHashCode() ?? 0;
            else
                return Error?.GetHashCode() ?? -1;
        }

        public static Try<A> Success(A value)
        {
            return new Try<A>(value);
        }

        public static Try<A> Fail(Exception e)
        {
            return new Try<A>(e);
        }

        public static Try<A> From(Func<A> fun)
        {
            try
            {
                return fun();
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public A Get()
        {
            if (!IsFailure)
                return Value;
            else
                throw Error;
        }

        public A GetOrElse(Func<A> fun)
        {
            if (IsSuccess)
                return Value;
            else
                return fun();
        }

        public Try<A> OrElse(Func<Try<A>> @default)
        {
            if (IsSuccess)
                return this;
            else
                return @default();
        }

        public Try<T> Transform<T>(Func<A, Try<T>> success, Func<Exception, Try<T>> fail)
        {
            if (IsSuccess)
                return success(Value);
            else
                return fail(Error);
        }
        public Try<A> RecoverWith<T>(Func<Exception,Try<A>> func)
        {
            if (IsFailure)
                return func(Error);
            else
                return this;
        }

        public Try<A> Recover(Func<Exception, A> func)
        {
            if (IsFailure)
                return Return(func(Error));
            else
                return this;
        }

        public T Match<T>(Func<A, T> success, Func<Exception, T> fail)
            => IsSuccess ? success(Value) : fail(Error);


        internal static Try<T> Return<T>(T x)
        {
            return Try<T>.From(() => x);
        }
        public static Try<A> Return(A x)
        {
            return Try<A>.From(() => x);
        }

        [Pure]
        public Try<B> FlatMap<B>(Func<A, Try<B>> f)
        {
            if (!IsFailure)
                return f(Get());
            else return Try<B>.Fail(Error);
        }

        [Pure]
        public Try<B> Map<B>(Func<A, B> f)
        {
            return FlatMap((A a) => Return(f(a)));
        }
        [Pure]
        public Try FlatMap(Func<A,Try> f)
        {
            if (!IsFailure)
                return f(Get());
            else return Try.Fail(Error);
        }

        [Pure]
        public Try Map(Action<A> f)
        {
            return FlatMap((A a) => Try.From(() => f(a)));
        }
        [Pure]
        public Try<B> Apply<B>(Try<Func<A, B>> fa)
        {
            return FlatMap((A a) => fa.Map<B>((Func<A, B> f) => f.Invoke(a)));
        }

        public Either<Exception,A> ToEither()
        {
            if (IsSuccess)
                return Either<Exception, A>.From(Value);
            else
                return Either<Exception, A>.From(new ArgumentNullException("Unexpected empty value"));
        }

        public Either<Exception, A> ToEither(String message)
        {
            if (IsSuccess)
                return Either<Exception, A>.From(Value);
            else
                return Either<Exception, A>.From(new ArgumentNullException(message));
        }

        public static implicit operator Try<A>(A right) => new Try<A>(right);
        public static implicit operator Try<A>(Exception e) => new Try<A>(e);
    }
}
