using System;
using System.Collections.Generic;

namespace Linked_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            Console.WriteLine(list.RemoveHead());

            list.AddHead(5);
            list.AddHead(6);
            list.AddTail(7);

            // 6 <-> 5 <-> 7

            list.AddTail(8);

            // 6 <-> 5 <-> 7 <-> 8

            list.AddTail(9);

            Console.WriteLine(list.Head.Next.Next.Next.Value);

            int removedTail = list.RemoveTail();

            Console.WriteLine(removedTail);
            Console.WriteLine(list.Tail.Value);

            Console.WriteLine("ForEach method:");
            list.ForEach(n => Console.WriteLine(n));

            Console.WriteLine($"object to list -> {string.Join(", ", list.ToList())}");

            int[] array = list.ToArray();
            Console.WriteLine($"object to array -> {string.Join(", ", list.ToArray())}");
        }
    }
}
