using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    public class ArrayCreator<T>
    {
        public static T[] Create(int count, T element)
        {
            T[] array = new T[count];

            Array.Fill(array, element);
            return array;
        } 
    }
}
