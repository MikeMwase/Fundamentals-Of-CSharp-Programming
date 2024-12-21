using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals_Of_CSharp_Programming.Classes.Trees_And_Graphs
{
    public class TreeNode<T>
    {
        private T value;

        private bool hasParent;

        public List<TreeNode<T>> children;

        public TreeNode(T value)
        {
            if(value == null)
            {
                throw new ArgumentNullException("Can not insert null values");
            }

            this.value = value;
            this.children = new List<TreeNode<T>>();
        }

        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public int ChildrenCount
        {
            get
            {
                return this.children.Count;
            }
        }

        public void AddChild(TreeNode<T> child)
        {
            if(child == null)
            {
                throw new ArgumentNullException("Can not insert null values");
            }

            if(child.hasParent)
            {
                throw new ArgumentException("Node alredy has a parent");
            }

            child.hasParent = true;

            children.Add(child);
        }

        public TreeNode<T> GetChild(int index)
        {
            return this.children[index];
        }
    }
    public class Tree<T>
    {
        TreeNode<T> root;

        public Tree(T value)
        {
            if(value == null)
            {
                throw new ArgumentNullException("Can not insert null values");
            }

            this.root = new TreeNode<T>(value);
        }

        public Tree(T value, params Tree<T>[] children): this(value)
        {
            foreach(Tree<T> child in children)
            {
                this.root.AddChild(child.root);
            }
        }

        private void printDFS(TreeNode<T> root, String spaces)
        {
            Console.WriteLine(spaces + root.Value);

            TreeNode<T> child = null;

            for(int i = 0; i < this.root.ChildrenCount; i ++)
            {
                child = this.root.GetChild(i);

                printDFS(child, spaces + spaces + "  ");
            }
        }

        private void printBFS(TreeNode<T> node)
        {
            Queue<TreeNode<T>> visitedNodesQueue = new Queue<TreeNode<T>>();

            visitedNodesQueue.Enqueue(node);

            while(visitedNodesQueue.Count > 0)
            {

                TreeNode<T> currentNode = visitedNodesQueue.Dequeue();

                Console.WriteLine(currentNode.Value);

                List<TreeNode<T>> children = currentNode.children;

                foreach(TreeNode<T> child in children)
                {
                    visitedNodesQueue.Enqueue(child);
                }

            }
        }

        public void TraverseTreeDFS()
        {
            this.printDFS(this.root, String.Empty);
        }

        public void TraverseTreeBFS()
        {
            this.printBFS(this.root);
        }
    }
}
