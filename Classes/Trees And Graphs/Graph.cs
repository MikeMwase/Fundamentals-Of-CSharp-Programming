using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals_Of_CSharp_Programming.Classes.Trees_And_Graphs
{
    public class Graph
    {
        public List<int>[] childNodes;

        public Graph(int size)
        {
            childNodes = new List<int>[size];

            for(int i = 0; i < size; i++)
            {
                childNodes[i] = new List<int>();
            }
        }

        public Graph(List<int>[] childNodes) 
        {
            this.childNodes = childNodes;
        }

        public int Size
        {
            get { return childNodes.Length; }
        }

        public void AddEdge(int u, int v)
        {
            childNodes[u].Add(v);
        }

        public void RemoveEdge(int u, int v) 
        {
            childNodes[u].Remove(v);
        }

        public bool HasEdge(int u, int v)
        {
            bool hasEdge = childNodes[0].Contains(v);
            return hasEdge;
        }

        public IList<int> GetSuccessor(int v)
        {
            return childNodes[v];
        }
    }
}
