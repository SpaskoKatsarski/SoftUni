namespace Problem04.BalancedParentheses
{
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            //if (parentheses.Length == 0 || parentheses.Length % 2 == 1)
            //    return false;

            //Stack<char> openingStack = new Stack<char>();
            //Queue<char> closingQueue = new Queue<char>();

            //foreach (char item in parentheses)
            //{
            //    if (item == ')' || item == ']' || item == '}')
            //    {
            //        closingQueue.Enqueue(item);
            //    }
            //    else
            //    {
            //        openingStack.Push(item);
            //    }
            //}

            //for (int i = 0; i < parentheses.Length / 2; i++)
            //{
            //    char opening = openingStack.Pop();
            //    char expected = default;
            //    if (opening == '(')
            //    {
            //        expected = ')';
            //    }
            //    else if (opening == '[')
            //    {
            //        expected = ']';
            //    }
            //    else if (opening == '{')
            //    {
            //        expected = '}';
            //    }

            //    if (closingQueue.Dequeue() != expected)
            //    {
            //        return false;
            //    }
            //}

            //return openingStack.Count == 0 && closingQueue.Count == 0;

            if (parentheses.Length == 0 || parentheses.Length % 2 == 1)
                return false;

            Stack<char> stack = new Stack<char>(parentheses.Length / 2);

            foreach (var item in parentheses)
            {
                char expectedChar = default;

                switch (item)
                {
                    case ')':
                        expectedChar = '(';
                        break;
                    case '}':
                        expectedChar = '{';
                        break;
                    case ']':
                        expectedChar = '[';
                        break;
                    default:
                        stack.Push(item);
                        break;
                }

                if (expectedChar == default)
                {
                    continue;
                }

                if (stack.Pop() != expectedChar)
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }
    }
}
