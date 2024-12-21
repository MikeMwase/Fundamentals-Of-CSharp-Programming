using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals_Of_CSharp_Programming.Classes.Trees_And_Graphs
{
    public class TraverseDirectoryBFS
    {
        public void TraverseDirBFS(String directoryPath)
        {
           Queue<DirectoryInfo> visitedDirQueue = new Queue<DirectoryInfo>();

            visitedDirQueue.Enqueue(new DirectoryInfo(directoryPath));

            while (visitedDirQueue.Count > 0)
            {
                DirectoryInfo currentDire = visitedDirQueue.Dequeue();

                Console.WriteLine(currentDire.FullName);

                DirectoryInfo[] children = currentDire.GetDirectories();

                foreach (DirectoryInfo child in children) 
                { 
                     visitedDirQueue.Enqueue((DirectoryInfo)child);
                }
            }
        }
    }

    
}
