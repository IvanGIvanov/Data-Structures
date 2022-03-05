namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            var tree = new Tree<int>(23,            // LVL:1
                new Tree<int>(76,                   // LVL:2
                    new Tree<int>(56),              // LVL:3
                    new Tree<int>(87)),             // LVL:3
                new Tree<int>(432,                  // LVL:2
                    new Tree<int>(124)));           // LVL:3


            var subtree = new Tree<int>(54, 
                new Tree<int>(24),
                new Tree<int>(3));

            Console.WriteLine(string.Join(", ", tree.OrderBfs()));
            Console.WriteLine(string.Join(", ", tree.OrderDfs()));
            Console.WriteLine(string.Join(", ", tree.OrderWithRecursiveDfs()));
            
        }
    }
}
