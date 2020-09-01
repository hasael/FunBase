using System;

namespace FunBase.Types
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
            return BiMap(_ => _, f);
        }

        public Either<T, TR> MapLeft<T>(Func<TL, T> f)
        {
            return BiMap(f, _ => _);
        }

        public Either<T1, T2> BiMap<T1, T2>(Func<TL, T1> left, Func<TR, T2> right)
        {
            if (IsRight)
                return new Either<T1, T2>(right(RightValue));
            else
                return new Either<T1, T2>(left(LeftValue));
        }

        public static implicit operator Either<TL, TR>(TL left) => new Either<TL, TR>(left);

        public static implicit operator Either<TL, TR>(TR right) => new Either<TL, TR>(right);
    }
}
