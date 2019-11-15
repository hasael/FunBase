using System;
using System.Diagnostics.Contracts;

namespace FunBase.ClassInstances
{
  
    public class Try
    {
        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;
        protected readonly Exception Error;
        protected Try(Exception error)
        {
            IsFailure = true;
            Error = error;
        }

        protected Try()
        {
            IsFailure = false;
        }

        public override bool Equals(object obj)
        {
            return obj?.GetHashCode() == this.GetHashCode();
        }

        public override int GetHashCode()
        {
            if (IsSuccess)
                return 0;
            else
                return Error?.GetHashCode() ?? -1;
        }

        public static Try Success()
        {
            return new Try();
        }

        public static Try Fail(Exception e)
        {
            return new Try(e);
        }

        public static Try From(Action fun)
        {
            try
            {
                fun();
                return Success();
            }
            catch (Exception ex)
            {
                return Fail(ex);
            }
        }
     
        public Try<T> Transform<T>(Func<Try<T>> success, Func<Exception, Try<T>> fail)
        {
            if (IsSuccess)
                return success();
            else
                return fail(Error);
        }
        public Try RecoverWith(Func<Exception, Try> func)
        {
            if (IsFailure)
                return func(Error);
            else
                return this;
        }

        public Try Recover(Action<Exception> func)
        {
            if (IsFailure)
                return From(() => func(Error));
            else
                return this;
        }
      
        public T Match<T>(Func<T> success, Func<Exception, T> fail)
            => IsSuccess ? success() : fail(Error);

  
        [Pure]
        public Try<B> FlatMap<B>(Func<Try<B>> f)
        {
            if (!IsFailure)
                return f();
            else return Try<B>.Fail(Error);
        }

        [Pure]
        public Try<B> Map<B>(Func<B> f)
        {
            return FlatMap(() => Try<B>.Return(f()));
        }

        [Pure]
        public Try FlatMap(Func<Try> f)
        {
            if (!IsFailure)
                return f();
            else return Try.Fail(Error);
        }

        [Pure]
        public Try Map(Action f)
        {
            return FlatMap(() => Try.From(f));
        }
        [Pure]
        public Try<B> Apply<B>(Try<Func<B>> fa)
        {
            return FlatMap(() => fa.Map<B>((Func<B> f) => f()));
        }

        public static implicit operator Try(Exception e) => new Try(e);
    }
   
}
