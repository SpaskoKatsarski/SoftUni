// Stack
Console.WriteLine("Stack operations:");
Console.WriteLine();

var collection = new Problem02.Stack.Stack<int>();
collection.Push(1);
collection.Push(2);
collection.Push(3);
collection.Push(4);

PrintItems(collection);

Console.WriteLine("Count: " + collection.Count);
int value = collection.Pop();
Console.WriteLine("Pop: " + value);
Console.WriteLine("Count: " + collection.Count);
Console.WriteLine("Contains 4: " + collection.Contains(4));
Console.WriteLine("Contains 3: " + collection.Contains(3));
Console.WriteLine("Peek: " + collection.Peek());

static void PrintItems(Problem02.Stack.Stack<int> collection)
{
    Console.WriteLine("Items:");
    foreach (var item in collection)
    {
        Console.WriteLine(item);
    }
}

Console.WriteLine("==============================");

// Queue
Console.WriteLine("Queue operations:");
Console.WriteLine();

var queue = new Problem03.Queue.Queue<int>();
queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);
queue.Enqueue(4);

PrintItemsQueue(queue);

Console.WriteLine("Count: " + queue.Count);
int value2 = queue.Dequeue();
Console.WriteLine("Dequeue: " + value2);
Console.WriteLine("Count: " + queue.Count);
Console.WriteLine("Contains 4: " + queue.Contains(4));
Console.WriteLine("Contains 3: " + queue.Contains(3));
Console.WriteLine("Peek: " + queue.Peek());

static void PrintItemsQueue(Problem03.Queue.Queue<int> queue)
{
    Console.WriteLine("Items:");
    foreach (var item in queue)
    {
        Console.WriteLine(item);
    }
}

Console.WriteLine("==============================");

// SinglyLinkedList
Console.WriteLine("SinglyLinkedList operations:");
Console.WriteLine();

var singlyLinkedList = new Problem04.SinglyLinkedList.SinglyLinkedList<int>();

singlyLinkedList.AddFirst(1);
singlyLinkedList.AddLast(2);
Console.WriteLine("Count: " + singlyLinkedList.Count);

singlyLinkedList.AddFirst(3);
Console.WriteLine("Count: " + singlyLinkedList.Count);

PrintItemsSinglyLinkedList(singlyLinkedList);

Console.WriteLine("GetFirts: " + singlyLinkedList.GetFirst());
Console.WriteLine("GetLast: " + singlyLinkedList.GetLast());

singlyLinkedList.RemoveFirst();
Console.WriteLine("Count: " + singlyLinkedList.Count);
PrintItemsSinglyLinkedList(singlyLinkedList);

singlyLinkedList.RemoveLast();
Console.WriteLine("Count: " + singlyLinkedList.Count);
PrintItemsSinglyLinkedList(singlyLinkedList);

static void PrintItemsSinglyLinkedList(Problem04.SinglyLinkedList.SinglyLinkedList<int> queue)
{
    Console.WriteLine("Items:");
    foreach (var item in queue)
    {
        Console.WriteLine(item);
    }
}