using System;

namespace FunBase.ClassInstances
{
    public class Either<TL, TR>
    {
        protected readonly TL LeftValue;
        protected readonly TR RightValue;
        protected readonly bool IsLeft;
        protected bool IsRight => !IsLeft;

        protected Either(TL leftValue)
        {
            this.LeftValue = leftValue;
            this.IsLeft = true;
        }

        protected Either(TR rightValue)
        {
            this.RightValue = rightValue;
            this.IsLeft = false;
        }

        public static Either<TL, TR> From(TL left)
        {
            return new Either<TL, TR>(left);
        }
        public static Either<TL, TR> From(TR right)
        {
            return new Either<TL, TR>(right);
        }

        public static Either<TL, TR> Left(TL left)
        {
            return new Either<TL, TR>(left);
        }
        public static Either<TL, TR> Right(TR right)
        {
            return new Either<TL, TR>(right);
        }


        public override bool Equals(object obj)
        {
            return obj?.GetHashCode() == this.GetHashCode();
        }

        public override int GetHashCode()
        {
            if (IsRight)
                return RightValue?.GetHashCode() ?? 0;
            else
                return LeftValue?.GetHashCode() ?? -1;
        }

        public T Match<T>(Func<TL, T> leftFunc, Func<TR, T> rightFunc)
            => this.IsLeft ? leftFunc(this.LeftValue) : rightFunc(this.RightValue);

        public Either<TL, T> MapRight<T>(Func<TR, T> f)
        {
            if (IsLeft)
                return new Either<TL, T>(LeftValue);
            else
                return new Either<TL, T>(f(RightValue));
        }

        public Either<T, TR> MapLeft<T>(Func<TL, T> f)
        {
            if (IsRight)
                return new Either<T, TR>(RightValue);
            else
                return new Either<T, TR>(f(LeftValue));
        }

        public static implicit operator Either<TL, TR>(TL left) => new Either<TL, TR>(left);

        public static implicit operator Either<TL, TR>(TR right) => new Either<TL, TR>(right);
    }
}
