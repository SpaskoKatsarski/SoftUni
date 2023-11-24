using _01.Two_Three;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            var tree = new TwoThreeTree<string>();
            tree.Insert("A");
            tree.Insert("E");
            tree.Insert("D");
            tree.Insert("B");
            tree.Insert("F");
            tree.Insert("G");
        }
    }
}
