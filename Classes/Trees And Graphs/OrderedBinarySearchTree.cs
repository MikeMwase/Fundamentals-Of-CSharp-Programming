using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals_Of_CSharp_Programming.Classes.Trees_And_Graphs
{
    public class OrderedBinarySearchTree<T> where T : IComparable<T>
    {
        internal class BinaryTreeNode<T> : IComparable<BinaryTreeNode<T>> where T : IComparable<T>
        {
            internal T value;

            internal BinaryTreeNode<T> parent;

            internal BinaryTreeNode<T> LeftChild;

            internal BinaryTreeNode<T> RightChild;

            public BinaryTreeNode(T value)
            {
                this.value = value;
                this.parent = null;
                this.LeftChild = null;
                this.RightChild = null;
            }

            public override string ToString()
            {
                return this.value.ToString();
            }

            public override int GetHashCode()
            {
                return this.value.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                BinaryTreeNode<T> other = (BinaryTreeNode<T>)obj;

                return this.CompareTo(other) == 0;
            }

            public int CompareTo(BinaryTreeNode<T> other)
            {
                return this.value.CompareTo(other.value);
            }
        }

        private BinaryTreeNode<T> root;

       
        public OrderedBinarySearchTree()
        {
            this.root = null;
        }

        private BinaryTreeNode<T> Insert(T value, BinaryTreeNode<T> parentNode, BinaryTreeNode<T> node)
        {
            if(node == null)
            {
                node = new BinaryTreeNode<T>(value);

                node.parent = parentNode;
            }
            else
            {
                int compareTo = value.CompareTo(node.value);

                if(compareTo < 0)
                {
                    node.LeftChild = Insert(value,node,node.LeftChild);
                }
                else if(compareTo > 0)
                {
                    node.RightChild = Insert(value,node,node.RightChild);
                }
            }

            return node;
        }

        public void Insert(T value)
        {
            root = Insert(value, null, this.root);
        }

        private BinaryTreeNode<T> Find(T value)
        {
            BinaryTreeNode<T> node = this.root;

            while (node != null)
            {
                int compareTo = value.CompareTo(node.value);

                if (compareTo < 0)
                {
                    node = node.LeftChild;
                }
                else if (compareTo > 0) 
                { 
                    node = node.RightChild;
                }
                else 
                {
                    break;
                }

            }

            return node;

        }

        public bool Contains(T value)
        {
            bool found = this.Find(value) != null;

            return found;
        }

        private void Remove(BinaryTreeNode<T> node)
        {
            if(node.LeftChild != null && node.RightChild != null)
            {
                BinaryTreeNode<T> replacement = node;

                while(replacement.LeftChild != null)
                {
                    replacement = replacement.LeftChild;
                }

                node.value = replacement.value;

                node = replacement;
            }

            BinaryTreeNode<T> theChild = node.LeftChild != null ? node.LeftChild : this.root;

            if(theChild == null)
            {
                theChild.parent = node.parent;

                if(node.parent == null)
                {
                    theChild = this.root;
                }
                else
                {
                    if(node.parent.LeftChild == node)
                    {
                        node.parent.LeftChild = theChild;
                    }
                    else
                    {
                        node.parent.RightChild = theChild;
                    }
                }
            }
            else
            {
                if(node.parent == null)
                {
                    root = null;
                }
                else
                {
                    if(node.parent.LeftChild == node)
                    {
                        node.parent.LeftChild = theChild;
                    }
                    else
                    {
                        node.parent.RightChild = theChild;
                    }
                }
            }
        }

        public void Remove(T value)
        {
            BinaryTreeNode<T> nodeToDelete = Find(value);

            if (nodeToDelete != null) 
            { 
                Remove(nodeToDelete);
            }
        }
    }
}
