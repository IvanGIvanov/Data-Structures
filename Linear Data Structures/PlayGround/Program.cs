using Problem02.Stack;
using Problem03.Queue;
using System;

namespace PlayGround
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>();

            queue.Enqueue(3);
            queue.Enqueue(8);
            queue.Enqueue(12);
            queue.Enqueue(4);
            queue.Enqueue(2);

            Console.WriteLine(queue.Peek());

            //var stack = new Stack<int>();

            //stack.Push(3);
            //stack.Push(2);
            //stack.Push(9);
            //stack.Push(14);

            //Console.WriteLine(stack.Peek());
        }
    }
}
