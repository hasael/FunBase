using System;
using System.Diagnostics.Contracts;

namespace FunBase.ClassInstances
{
    public class Option<A>
    {
        public bool IsDefined { get; }
        public bool IsEmpty => !IsDefined;

        protected readonly A Value;
   
        protected Option(bool isDefined, A value)
        {
            IsDefined = isDefined;
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj?.GetHashCode() == this.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Value?.GetHashCode() ?? 0;
        }

        public static Option<A> None()
        {
            return new Option<A>(false, default);
        }

        public static Option<A> From(A a)
        {
            if (a == null)
            {
                return None();

            }
            else
            {
                return new Option<A>(true, a);
            }
        }

        public A Get()
        {
            if (IsDefined)
                return Value;
            else
                throw new ArgumentNullException($"Option is empty for value of {typeof(A).Name}");
        }

        public A GetOrElse(A @default)
        {
            if (IsDefined)
                return Value;
            else
                return @default;
        }

        public A GetOrElse(Func<A> defaultFunc)
        {
            if (IsDefined)
                return Value;
            else
                return defaultFunc();
        }

        public Option<A> OrElse(Func<Option<A>> @default)
        {
            if (IsDefined)
                return this;
            else return @default();
        }

        public Option<A> Filter(Func<A, Boolean> func)
        {
            if (IsDefined && func(Value))
                return this;
            else
                return None();
        }
        public bool Exists(Func<A, Boolean> func)
        {
            if (IsDefined && func(Value))
                return true;
            else
                return false;
        }

        public T Match<T>(Func<A, T> success, Func<T> none)
          => IsDefined ? success(Value) : none();

        private static Option<T> Return<T>(T x)
        {
            return Option<T>.From(x);
        }
        public static Option<A> Return(A x)
        {
            return From(x);
        }

        [Pure]
        public Option<B> FlatMap<B>(Func<A, Option<B>> f)
        {
            if (IsDefined)
                return f(Get());
            else return Option<B>.None();
        }

        [Pure]
        public Option<B> Map<B>(Func<A, B> f)
        {
            return FlatMap((A a) => Return(f(a)));
        }

        [Pure]
        public Option<B> Apply<B>(Option<Func<A, B>> fa)
        {
            return FlatMap((A a) => fa.Map<B>((Func<A, B> f) => f.Invoke(a)));
        }

        public static implicit operator Option<A>(A value) => From(value);
    }
}
