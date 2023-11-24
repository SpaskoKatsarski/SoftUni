using _01.RedBlackTree;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            var rbt = new RedBlackTree<int>();

            rbt.Insert(10);
            rbt.Insert(5);
            rbt.Insert(3);
        }
    }
}
