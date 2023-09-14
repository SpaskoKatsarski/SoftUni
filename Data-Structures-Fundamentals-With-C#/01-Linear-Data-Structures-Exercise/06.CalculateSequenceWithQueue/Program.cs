int n = int.Parse(Console.ReadLine());

Queue<int> queue = new Queue<int>();

queue.Enqueue(n);

List<int> result = new List<int>();

while (result.Count < 50)
{
    int currentNum = queue.Dequeue();
    result.Add(currentNum);

    queue.Enqueue(currentNum + 1);
    queue.Enqueue(2 * currentNum + 1);
    queue.Enqueue(currentNum + 2);
}

Console.WriteLine(string.Join(", ", result));