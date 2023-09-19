namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Tree<char> tree = new Tree<char>('A', 
                new Tree<char>('B'
                    ,new Tree<char>('D')
                    , new Tree<char>('E')),
                new Tree<char>('C',
                    new Tree<char>('F')));

            tree.Swap('C', 'F');
        }
    }
}
