
namespace GenericsDogsAndCircles
{
    internal class CircleCompareByX : IComparer<Circle>
    {
        public int Compare(Circle? x, Circle? y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException("Arguments cannot be null.");

            return x.X.CompareTo(y.X);
        }
    }
}
