using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals_Of_CSharp_Programming.Classes.Trees_And_Graphs
{
    public class TreeNode<T>
    {
        public T value;

        public bool hasParent;

        public List<TreeNode<T>> children;

        public TreeNode(T value) 
        { 
            if(value == null)
            {
               throw new ArgumentNullException("Can not insert null value");
            }

            this.value = value;
            this.children = new List<TreeNode<T>>();
        }

        public T Value
        {
            get
            {
                return value;
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
                throw new ArgumentException("Child already has a parent");
            }

            child.hasParent = true;
            this.children.Add(child);
        }

        public TreeNode<T> GetChild(int index)
        {
            return this.children[index];
        }
    }


    public class Tree<T>
    {
        public TreeNode<T> root;

        public Tree(T value) 
        {
            if(value == null)
            {
                throw new ArgumentNullException("Can not insert null value");
            }

            this.root = new TreeNode<T>(value);
        }

        public Tree(T value, params Tree<T>[] children)
        {
            foreach(Tree<T> child in children)
            {
                this.root.AddChild(child.root);
            }
        }

        public TreeNode<T> Root
        {
            get
            {
                return this.root;
            }
        }

    }
}
