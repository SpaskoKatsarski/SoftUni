using System;
using System.Collections.Generic;
using System.Linq;

namespace StartUp
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            //List<int> list2 = new List<int>();

            //list2.Add(2);
            //list2.Add(1);
            //list2.Add(2);
            //list2.Add(2);

            //int number2 = list2.Find(n => n == 1);
            //Console.WriteLine(number2);

            //List<int> numberList = list2.FindAll(n => n == 1);
            //Console.WriteLine(numberList);

            Console.WriteLine("---------------------------------------");
            Console.WriteLine(">>>>>>>>>>>>>>>>MY LIST<<<<<<<<<<<<<<<");
            Console.WriteLine("---------------------------------------");

            var list = new MyList<int>();

            list.Add(4);
            list.Add(2);
            list.Add(6);
            list.Add(8);

            list.Insert(3, 99);

            Console.WriteLine(list[0]);
            Console.WriteLine(list[1]);
            Console.WriteLine(list[2]);

            //Console.WriteLine($"Contains 4: {list.Contains(4)}");
            //Console.WriteLine($"Contains 98: {list.Contains(98)}");

            Console.WriteLine("Before swap:");
            Console.WriteLine(list[0]);
            Console.WriteLine(list[1]);
            list.Swap(0, 1);
            Console.WriteLine("After swap:");
            Console.WriteLine(list[0]);
            Console.WriteLine(list[1]);

            Console.WriteLine("Find method:");
            Console.WriteLine(list.Find(n => n == 231));
            Console.WriteLine(list.Find(n => n == 4));
            Console.WriteLine(list.Find(n => n % 2 == 0));


            Console.WriteLine("<<<<<<<<<<<<<<<<<<<STRING LIST>>>>>>>>>>>>>>>>>");
            MyList<string> myList = new MyList<string>();
            myList.Add("Ivan");
            myList.Add("Spasko");
            myList.Add("Alex");
            myList.Add("Dimitrichko");

            myList.Insert(2, "<<INSERTED>>");
            Console.WriteLine(myList[2]);
            Console.WriteLine(myList.RemoveAt(2));
            Console.WriteLine(myList.Count);
            //myList.Swap(-1, 2);
            Console.WriteLine(myList.Find(x => x[0] == 'A'));
            Console.WriteLine(myList);

            Console.WriteLine("---------------------------------------");
            Console.WriteLine(">>>>>>>>>>>>>>>>MY STACK<<<<<<<<<<<<<<<");
            Console.WriteLine("---------------------------------------");

            MyStack stack = new MyStack();
            stack.Push(2);
            stack.Push(34);
            stack.Push(6);
            stack.Push(3);
            stack.Push(1);
            Console.WriteLine(stack.GetPapacity());
            stack.Pop();
            Console.WriteLine("Peek after Pop -> ");
            Console.WriteLine(stack.Peek());

            Console.WriteLine();
            Console.WriteLine("ForEach method:");
            stack.ForEach(x => Console.WriteLine(x));
            stack.ForEach(x => x++); //Doesn't work in the internal array, because we just get the elements and don't change them in it.
            stack.ForEach(x => Console.WriteLine(x)); //Stays the same.

            Console.WriteLine("---------------------------------------");
            Console.WriteLine(">>>>>>>>>>>>>>>>MY QUEUE<<<<<<<<<<<<<<<");
            Console.WriteLine("---------------------------------------");

            MyQueue myQueue = new MyQueue();
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.Enqueue(4);
            myQueue.Enqueue(5);

            Console.WriteLine(myQueue.Dequeue());
            Console.WriteLine(myQueue.Peek());

            Console.WriteLine("ForEach:");
            myQueue.ForEach(x => Console.WriteLine(x));
        }
    }
}
