namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                this.Element = element;
                this.Next = next;
            }

            public Node(T element)
            {
                this.Element = element;
            }
        }

        private Node head;

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            if (this.head == null)
            {
                this.head = new Node(item);
                this.Count++;
                return;
            }

            var node = this.head;

            while (node.Next != null)
            {
                node = node.Next;
            }

            node.Next = new Node(item);
            this.Count++;
        }

        public T Dequeue()
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }
            return this.head.Element;
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;
            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}