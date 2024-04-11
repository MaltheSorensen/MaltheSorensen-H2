
#region Dog objects
using GenericsDogsAndCircles;
using System.Security.Cryptography;

Dog dog1 = new Dog("King", 70, 55);
Dog dog2 = new Dog("Spot", 30, 10);
Dog dog3 = new Dog("Rufus", 80, 40);
#endregion

#region Circle objects
Circle c1 = new Circle(10, 2, 3);
Circle c2 = new Circle(15, 6, 0);
Circle c3 = new Circle(8, 12, 7);
#endregion

#region ObjectComparer test
BetterObjectComparer<Dog> DogComparer = new BetterObjectComparer<Dog>();
BetterObjectComparer<Circle> CircleComparer = new BetterObjectComparer<Circle>();
Console.WriteLine(DogComparer.Largest(dog1, dog2, dog3));
Console.WriteLine(CircleComparer.Largest(c1, c2, c3));

EvenBetterObjectComparer comparer = new EvenBetterObjectComparer();

Dog LargestDog = comparer.Largest(dog1, dog2, dog3, new DogCompareByHight);
Circle LargestCircle = comparer.Largest(c1, c2, c3, new CircleCompareByX);

Console.WriteLine ($"{LargestDog.Name} has a height of {LargestDog.Height}");
Console.WriteLine($"{LargestCircle.Radius} is the largest circles radius");
#endregion
