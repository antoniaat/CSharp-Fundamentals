using System;

namespace Scale
{
    public class Scale<T>
        where T : IComparable<T>
    {
        private readonly T left;

        private readonly T right;

        public Scale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public T GetHeavier()
        {
            if (left.CompareTo(right) > 0)
            {
                return left;
            }
            else if (left.CompareTo(right) < 0)
            {
                return right;
            }
            return default(T);
        }
    }
}
