using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals_Of_CSharp_Programming.Classes.Dictionaries__HashTables_And_Sets
{
    public class StudentsExample
    {
        static void DictionaryOperations()
        {
            IDictionary<String, double> studentMarks = new Dictionary<String, double>(6);

            studentMarks["Allan"] = 3.00;

            studentMarks["Helen"] = 4.50;

            studentMarks["Tom"] = 5.50;

            studentMarks["James"] = 3.50;

            studentMarks["Mary"] = 5.00;
            
            studentMarks["Nerdy"] = 6.00;

            double marysMarks = studentMarks["Mary"];
            Console.WriteLine("Mary's marks: {0:0.00}", marysMarks);
            studentMarks.Remove("Mary");

            Console.WriteLine("Mary's marks removed");

            Console.WriteLine("Is Mary in the dictionary: {0} ?", studentMarks.ContainsKey("Mary") ? "YES!" : "NO!");

            Console.WriteLine("Nerdy's mark is {0:0.00}", studentMarks["Nerdy"]);

            studentMarks["Nerdy"] = 3.25;

            Console.WriteLine("But we all know he deserves no more than {0:0.00}", studentMarks["Nerdy"]);

            double annaMarks;

            bool findAnna = studentMarks.TryGetValue("Anna",out annaMarks);

            Console.WriteLine("Is Anna's mark in the dictionary? {0}", findAnna ? "Yes!" : "No");

            annaMarks = 6.00;

            findAnna = studentMarks.TryGetValue("Anna", out annaMarks);

            Console.WriteLine("Let's try again: {0}, Anna's mark is {1}.", findAnna ? "Yes!" : "No", annaMarks);
             
            Console.WriteLine("Students and Marks");

            foreach(KeyValuePair<string,double> studentMark in studentMarks)
            {
                Console.WriteLine("{0} has {1:0.00}", studentMark.Key,studentMark.Value);
            }

            Console.WriteLine("There are {0} in the dictionary", studentMarks.Count);

            studentMarks.Clear();

            Console.WriteLine("Students in the dictionary cleared.");

            Console.WriteLine("Is the dictionary empty:", studentMarks.Count == 0);
        }
    }
}
