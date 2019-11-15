using System;
using System.Diagnostics.Contracts;

namespace FunBase.TypeClasses
{
    public abstract class Applicative<A>
    {
        /// <summary>
        /// Apply
        /// </summary>
        /// <param name="fa">Applicative to apply</param>
        /// <returns>Applicative of type FB derived from Applicative of B</returns>

        public Applicative<A> Pure(A x)
        {
            return Pure(x);
        }

        public abstract Applicative<T> Pure<T>(T x);

        [Pure]
        public abstract Applicative<B> Apply<B>(Applicative<Func<A, B>> fa);

        [Pure]
        public Applicative<B> Map<B>(Func<A, B> f)
        {
            return Apply(Pure(f));
        }

    }
}
