using System;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int? jNullable = null;
            if (jNullable is null && int.Parse(Console.ReadLine()) is int a && a < 5)
            {
                Console.WriteLine("Its not null!");
            }

            int i = 50;
            object obj = "abc";
            string str = obj as string;

            if (obj is string a && a.Length > 1)
            {
                Console.WriteLine(true);
                Console.WriteLine(a);
            }
        }
    }
}
