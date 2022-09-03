using System;

namespace GenericArrayCreator
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = ArrayCreator<int>.Create(5, 10);
            Console.WriteLine(string.Join(" ", numbers));

            string[] words = ArrayCreator<string>.Create(5, "Ivan");
            Console.WriteLine(string.Join(" ", words));
        }
    }
}
