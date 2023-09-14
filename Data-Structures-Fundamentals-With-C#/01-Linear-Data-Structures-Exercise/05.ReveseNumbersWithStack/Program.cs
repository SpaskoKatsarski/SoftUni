Stack<int> stack = new Stack<int>();

int[] cmdArgs = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

foreach (var item in cmdArgs)
{
    stack.Push(item);
}

List<int> result = new List<int>();

while (stack.Count > 0)
{
    result.Add(stack.Pop());
}

Console.WriteLine(string.Join(' ', result));