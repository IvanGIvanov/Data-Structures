﻿namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private List<T> elements;

        public MaxHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapUp(this.elements.Count - 1);
        }

        private void HeapUp(int index)
        {
            var parentIndex = (index - 1) / 2;
            while (index > 0 && this.elements[index].CompareTo(this.elements[parentIndex]) > 0)
            {
                this.Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        private void Swap(int index, int parentIndex)
        {
            var temp = this.elements[index];
            this.elements[index] = this.elements[parentIndex];
            this.elements[parentIndex] = temp;

        }

        public T ExtractMax()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T element = this.elements[0];
            this.Swap(0, this.elements.Count - 1);
            this.elements.RemoveAt(elements.Count - 1);
            this.HeapDown(0);

            return element;
        }

        private void HeapDown(int index)
        {
            var biggerChildIndex = this.GetBiggerChildIndex(index);

            while ((biggerChildIndex < this.elements.Count && biggerChildIndex >= 0) && this.elements[biggerChildIndex].CompareTo(this.elements[index]) > 0)
            {
                this.Swap(biggerChildIndex, index);

                index = biggerChildIndex;
                biggerChildIndex = this.GetBiggerChildIndex(index);
            }
        }

        private int GetBiggerChildIndex(int index)
        {
            var firstChildIndex = index * 2 + 1;
            var secondChildIndex = index * 2 + 2;

            if (secondChildIndex < this.elements.Count)
            {
                if (this.elements[firstChildIndex].CompareTo(this.elements[secondChildIndex]) > 0)
                {
                    return firstChildIndex;
                }

                return secondChildIndex;
            }
            else if (firstChildIndex < this.elements.Count)
            {
                return firstChildIndex;
            }
            else
            {
                return -1;
            }
        }

        public T Peek()
        {
            return this.elements[0];
        }
    }
}
