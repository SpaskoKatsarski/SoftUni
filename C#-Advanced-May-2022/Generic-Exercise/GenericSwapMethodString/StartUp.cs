using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<double> list = new List<double>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                list.Add(input);
            }

            Box<double> box = new Box<double>(list);

            var elementToCompare = double.Parse(Console.ReadLine());
            var count = box.CountOfGreaterElements(list, elementToCompare);
            Console.WriteLine(count);
        }
    }
}
