using System;
using System.Diagnostics.Contracts;

namespace FunBase.TypeClasses
{
    public abstract class Functor<A>
    {
        /// <summary>
        /// Projection from one value to another
        /// </summary>
        /// <param name="f">Projection function</param>
        /// <returns>Mapped functor</returns>
   
        [Pure]
        public abstract Functor<B> Map<B>(Func<A, B> f);
    }
}
