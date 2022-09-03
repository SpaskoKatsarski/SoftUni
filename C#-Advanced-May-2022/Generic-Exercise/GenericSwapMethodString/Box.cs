using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericSwapMethodString
{
    public class Box<T> : IComparable<T> where T : IComparable
    {
        public Box(T value)
        {
            Value = value;
        }

        public Box(List<T> list)
        {
            List = list;
        }

        public T Value { get; }

        public List<T> List { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var element in List)
            {
                sb.AppendLine($"{typeof(T)}: {element}");
            }

            return sb.ToString().TrimEnd();
        }

        public void Swap(List<T> list, int firstIndex, int secondIndex)
        {
            T firstElement = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = firstElement;
        }

       public int CompareTo(T value)
        {
            return Value.CompareTo(value);
        }

        //public int CountOfGreaterElements<T>(List<T> list, T readLine) where T : IComparable =>
        //    list.Count(word => word.CompareTo(readLine) > 0);

        public int CountOfGreaterElements(List<T> list, T valueForCompare)
        {
            return list.Count(e => e.CompareTo(valueForCompare) > 0);
        }
            
    }
}
