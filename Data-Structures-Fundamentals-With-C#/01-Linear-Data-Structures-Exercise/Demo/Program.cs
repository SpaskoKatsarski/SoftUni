using Problem01.CircularQueue;

CircularQueue<int> queue = new CircularQueue<int>();

queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);

Console.WriteLine(queue.Dequeue());

queue.Enqueue(999);
queue.Enqueue(1000);

foreach (var item in queue)
{
    Console.WriteLine(item);
}

queue.Enqueue(1000);

int[] arr = queue.ToArray();

Console.WriteLine(queue.Peek());