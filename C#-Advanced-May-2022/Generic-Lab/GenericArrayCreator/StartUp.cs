using System;

namespace GenericArrayCreator
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = ArrayCreator.Create<int>(5, 10);
            Console.WriteLine(string.Join(" ", numbers));

            string[] words = ArrayCreator.Create<string>(5, "Ivan");
            Console.WriteLine(string.Join(" ", words));
        }
    }
}
