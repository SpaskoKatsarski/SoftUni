using Problem04.BalancedParentheses;

var brackets = new BalancedParenthesesSolve();

//edge case
string input = "{{[[}]]}";
bool result = brackets.AreBalanced(input);
Console.WriteLine(result);