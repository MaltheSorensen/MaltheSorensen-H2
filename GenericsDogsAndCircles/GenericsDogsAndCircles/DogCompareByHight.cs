
using System.Reflection.Metadata.Ecma335;

namespace GenericsDogsAndCircles
{
    public class DogCompareByHight : IComparer<Dog>
    {
        public int Compare(Dog? x, Dog? y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException("Arguments cannot be null.");

            return x.Height.CompareTo(y.Height);
        }
    }
}
