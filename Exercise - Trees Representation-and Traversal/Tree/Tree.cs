namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.AddChild(child);
                child.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string AsString()
        {
            var sb = new StringBuilder();

            this.DfsAsString(sb, this, 0);

            return sb.ToString().Trim();
        }

        private void DfsAsString(StringBuilder sb, Tree<T> tree, int indent)
        {
            sb.Append(' ', indent)
                .AppendLine(tree.Key.ToString());

            foreach (var child in tree.children)
            {
                DfsAsString(sb, child, indent + 2);
            }

        }

        public IEnumerable<T> GetInternalKeys()
        {
            return this.DfsWithResultKeys(tree => tree.children.Count > 0 && tree.Parent != null);
        }

        private IEnumerable<T> DfsWithResultKeys(Predicate<Tree<T>> predicate)
        {
            var result = new List<T>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var element = queue.Dequeue();

                if (predicate.Invoke(element))
                {
                    result.Add(element.Key);
                }

                foreach (var child in element.children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public IEnumerable<T> GetLeafKeys()
        {
            return this.DfsWithResultKeys(tree => tree.children.Count == 0);
        }

        public T GetDeepestKey()
        {
            return this.GetDeepestNode(this).Key;
        }

        private Tree<T> GetDeepestNode(Tree<T> tree)
        {
            var leaves 
        }

        public IEnumerable<T> GetLongestPath()
        {
            throw new NotImplementedException();
        }
    }
}
