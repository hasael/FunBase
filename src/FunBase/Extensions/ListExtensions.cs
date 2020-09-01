using System;
using System.Collections.Generic;
using System.Linq;

namespace FunBase.Extensions
{
    public static class ListExtensions
    {
        public static List<B> FlatMap<A, B>(this List<A> self, Func<A, List<B>> func)
        {
            return self.SelectMany(func).ToList();
        }
        public static List<B> Map<A, B>(this List<A> self, Func<A, B> func)
        {
            return self.Select(func).ToList();
        }

    }
}
