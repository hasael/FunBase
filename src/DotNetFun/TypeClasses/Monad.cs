using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace FunBase.TypeClasses
{
    public abstract class Monad<A>
    {
        /// <summary>
        /// Monad constructor function.  Provide the bound value A to construct
        /// a new monad of type MA.
        /// </summary>
        /// <param name="x">Value to bind</param>
        /// <returns>Monad of type MA</returns>
        public Monad<A> Return(A x)
        {
            return Return(x);
        }

        public abstract Monad<T> Return<T>(T x);
        /// <summary>
        /// Monadic bind
        /// </summary>
        /// <typeparam name="B">Type of the bound return value</typeparam>
        /// <param name="f">Bind function</param>
        /// <returns>Monad of type `MB` derived from Monad of `B`</returns>
        [Pure]
        public abstract Monad<B> FlatMap<B>(Func<A, Monad<B>> f);

            
        [Pure]
        public Monad<B> Map<B>(Func<A, B> f)
        {
            return FlatMap(a => Return(f(a)));
        }

        [Pure]
        public Monad<B> Apply<B>(Monad<Func<A, B>> fa)
        {
            return FlatMap(a => fa.Map(f => f.Invoke(a)));
        }
        
    }
}