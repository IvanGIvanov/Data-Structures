namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;
        private T value;
        private Tree<T> parent;

        public Tree(T value)
        {
            this.value = value;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parentNode = this.FindNode(parentKey);

            if (parentNode is null)
            {
                throw new ArgumentNullException();
            }
            parentNode.children.Add(child);
            child.parent = parentNode;

        }

        private Tree<T> FindNode(T parentKey)
        {
            var queue = new Queue<Tree<T>>();
            var result = new List<T>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                result.Add(subtree.value);

                if (subtree.value.Equals(parentKey))
                {
                    return subtree;
                }

                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public IEnumerable<T> OrderBfs()
        {
            var queue = new Queue<Tree<T>>();
            var result = new List<T>();

            queue.Enqueue(this);        

            while (queue.Count > 0)     
            {
                var subtree = queue.Dequeue();  
                result.Add(subtree.value);

                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public IEnumerable<T> OrderDfs()                    // DFS with stack
        {
            var result = new Stack<T>();
            var stack = new Stack<Tree<T>>();

            stack.Push(this);

            while (stack.Count > 0)
            {
                var node = stack.Pop();

                foreach (var child in node.children)
                {
                    stack.Push(child);
                }

                result.Push(node.value);
            }

            return result;
        }

        public IEnumerable<T> OrderWithRecursiveDfs()
        {
            var list = new List<T>();

            this.RecursiveDfs(this, list);

            return list;
        }

        public void RemoveNode(T nodeKey)
        {
            var removeNode = FindNode(nodeKey);

            if (removeNode is null)
            {
                throw new ArgumentNullException();
            }

            var parentNode = removeNode.parent;

            if (parentNode is null)
            {
                throw new ArgumentException();
            }

            parentNode.children.Remove(removeNode);
            //parentNode.children = parentNode.children.Where(node => !node.value.Equals(nodeKey)).ToList();
            //removeNode.parent = null;
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = this.FindNode(firstKey);
            var secondNode = this.FindNode(secondKey);

            if (firstNode is null || secondKey is null)
            {
                throw new ArgumentNullException();
            }

            var firstNodeParent = firstNode.parent;
            var secondNodeParent = secondNode.parent;

            if (firstNodeParent is null || secondNodeParent is null)
            {
                throw new ArgumentException();
            }

            var firstChildIndex = firstNodeParent.children.IndexOf(firstNode);
            var secondChildIndex = secondNodeParent.children.IndexOf(secondNode);

            firstNodeParent.children[firstChildIndex] = secondNode;
            secondNode.parent = firstNodeParent;
            secondNodeParent.children[secondChildIndex] = firstNode;
            firstNode.parent = secondNodeParent;

        }

        public void RecursiveDfs(Tree<T> node, ICollection<T> result)       // Recursive DFS
        {
            foreach (var child in node.children)
            {
                this.RecursiveDfs(child, result);
            }

            result.Add(node.value);
        }
    }
}
