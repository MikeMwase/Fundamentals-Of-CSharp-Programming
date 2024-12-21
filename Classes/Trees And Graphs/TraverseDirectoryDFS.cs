using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals_Of_CSharp_Programming.Classes.Trees_And_Graphs
{
    public class TraverseDirectoryDFS
    {
        private void TraverseDir(DirectoryInfo dir, String spaces)
        {
            Console.WriteLine(spaces + dir.FullName);

            DirectoryInfo[] children = dir.GetDirectories();

            foreach (DirectoryInfo child in children) 
            { 
               TraverseDir(child, spaces + "  ");
            }
        }

        public void TraverseDir(string directoryPath)
        {
            this.TraverseDir(new DirectoryInfo(directoryPath),String.Empty);
        }
    }
}
