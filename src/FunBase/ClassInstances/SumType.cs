using System;

namespace FunBase.ClassInstances
{
    public abstract class SumType<T,TA,TB>
    where TA:T 
    where TB:T
    {
        protected abstract T Instance { get; }

        public A Match<A>(Func<TA, A> funcA, Func<TB, A> funcB)
        {
            if (Instance is TA)
                return funcA((TA) Instance);
            else if (Instance is TB)
                return funcB((TB) Instance);

            throw new ArgumentException($"Cannot parse type of {GetType()}");
        }
    }

    public abstract class SumType<T, TA, TB, TC>
        where TA : T
        where TB : T
        where TC : T
    {
        protected abstract T Instance { get; }

        public A Match<A>(Func<TA, A> funcA, Func<TB, A> funcB, Func<TC, A> funcC)
        {
            if (Instance is TA)
                return funcA((TA)Instance);
            else if (Instance is TB)
                return funcB((TB)Instance);
            else if (Instance is TC)
                return funcC((TC)Instance);

            throw new ArgumentException($"Cannot parse type of {GetType()}");
        }
    }

    public abstract class SumType<T, TA, TB, TC, TD>
        where TA : T
        where TB : T
        where TC : T
        where TD : T
    {
        protected abstract T Instance { get; }

        public A Match<A>(Func<TA, A> funcA, Func<TB, A> funcB, Func<TC, A> funcC, Func<TD, A> funcD)
        {
            if (Instance is TA)
                return funcA((TA)Instance);
            else if (Instance is TB)
                return funcB((TB)Instance);
            else if (Instance is TC)
                return funcC((TC)Instance);
            else if (Instance is TD)
                return funcD((TD)Instance);

            throw new ArgumentException($"Cannot parse type of {GetType()}");
        }
    }

    public abstract class SumType<T, TA, TB, TC, TD, TE>
        where TA : T
        where TB : T
        where TC : T
        where TD : T
        where TE : T
    {
        protected abstract T Instance { get; }

        public A Match<A>(Func<TA, A> funcA, Func<TB, A> funcB, 
            Func<TC, A> funcC, Func<TD, A> funcD, Func<TE, A> funcE)
        {
            if (Instance is TA)
                return funcA((TA)Instance);
            else if (Instance is TB)
                return funcB((TB)Instance);
            else if (Instance is TC)
                return funcC((TC)Instance);
            else if (Instance is TD)
                return funcD((TD)Instance);
            else if (Instance is TE)
                return funcE((TE)Instance);

            throw new ArgumentException($"Cannot parse type of {GetType()}");
        }
    }
    public abstract class SumType<T, TA, TB, TC, TD, TE, TF>
        where TA : T
        where TB : T
        where TC : T
        where TD : T
        where TE : T
        where TF : T
    {
        protected abstract T Instance { get; }

        public A Match<A>(Func<TA, A> funcA, Func<TB, A> funcB,
            Func<TC, A> funcC, Func<TD, A> funcD, Func<TE, A> funcE, Func<TF, A> funcF)
        {
            if (Instance is TA)
                return funcA((TA)Instance);
            else if (Instance is TB)
                return funcB((TB)Instance);
            else if (Instance is TC)
                return funcC((TC)Instance);
            else if (Instance is TD)
                return funcD((TD)Instance);
            else if (Instance is TE)
                return funcE((TE)Instance);
            else if (Instance is TF)
                return funcF((TF)Instance);

            throw new ArgumentException($"Cannot parse type of {GetType()}");
        }
    }

    public abstract class SumType<T, TA, TB, TC, TD, TE, TF, TG>
        where TA : T
        where TB : T
        where TC : T
        where TD : T
        where TE : T
        where TF : T
        where TG : T
    {
        protected abstract T Instance { get; }

        public A Match<A>(Func<TA, A> funcA, Func<TB, A> funcB,
            Func<TC, A> funcC, Func<TD, A> funcD, Func<TE, A> funcE, Func<TF, A> funcF, Func<TG, A> funcG)
        {
            if (Instance is TA)
                return funcA((TA)Instance);
            else if (Instance is TB)
                return funcB((TB)Instance);
            else if (Instance is TC)
                return funcC((TC)Instance);
            else if (Instance is TD)
                return funcD((TD)Instance);
            else if (Instance is TE)
                return funcE((TE)Instance);
            else if (Instance is TF)
                return funcF((TF)Instance);
            else if (Instance is TG)
                return funcG((TG)Instance);

            throw new ArgumentException($"Cannot parse type of {GetType()}");
        }
    }
    public abstract class SumType<T, TA, TB, TC, TD, TE, TF, TG, TH>
        where TA : T
        where TB : T
        where TC : T
        where TD : T
        where TE : T
        where TF : T
        where TG : T
        where TH : T
    {
        protected abstract T Instance { get; }

        public A Match<A>(Func<TA, A> funcA, Func<TB, A> funcB,
            Func<TC, A> funcC, Func<TD, A> funcD, Func<TE, A> funcE, Func<TF, A> funcF, Func<TG, A> funcG, Func<TH, A> funcH)
        {
            if (Instance is TA)
                return funcA((TA)Instance);
            else if (Instance is TB)
                return funcB((TB)Instance);
            else if (Instance is TC)
                return funcC((TC)Instance);
            else if (Instance is TD)
                return funcD((TD)Instance);
            else if (Instance is TE)
                return funcE((TE)Instance);
            else if (Instance is TF)
                return funcF((TF)Instance);
            else if (Instance is TG)
                return funcG((TG)Instance);
            else if (Instance is TH)
                return funcH((TH)Instance);

            throw new ArgumentException($"Cannot parse type of {GetType()}");
        }
    }
    public abstract class SumType<T, TA, TB, TC, TD, TE, TF, TG, TH, TI>
        where TA : T
        where TB : T
        where TC : T
        where TD : T
        where TE : T
        where TF : T
        where TG : T
        where TH : T
        where TI : T
    {
        protected abstract T Instance { get; }

        public A Match<A>(Func<TA, A> funcA, Func<TB, A> funcB,
            Func<TC, A> funcC, Func<TD, A> funcD, Func<TE, A> funcE, Func<TF, A> funcF, Func<TG, A> funcG, Func<TH, A> funcH, Func<TI, A> funcI)
        {
            if (Instance is TA)
                return funcA((TA)Instance);
            else if (Instance is TB)
                return funcB((TB)Instance);
            else if (Instance is TC)
                return funcC((TC)Instance);
            else if (Instance is TD)
                return funcD((TD)Instance);
            else if (Instance is TE)
                return funcE((TE)Instance);
            else if (Instance is TF)
                return funcF((TF)Instance);
            else if (Instance is TG)
                return funcG((TG)Instance);
            else if (Instance is TH)
                return funcH((TH)Instance);
            else if (Instance is TI)
                return funcI((TI)Instance);


            throw new ArgumentException($"Cannot parse type of {GetType()}");
        }
    }
}
