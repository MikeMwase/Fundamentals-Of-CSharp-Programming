using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals_Of_CSharp_Programming.Classes.Dictionaries__HashTables_And_Sets
{
    public class WordCountingWithSortedDictionary
    {
        private static readonly string Text =
           "Mary had a little lamb " +
           "little Lamb, little Lamb, " +
           "Mary had a Little lamb, " +
           "whose fleece were white as snow.";

        private static IDictionary<String, int> GetWordOccurrenceMap(string text)
        {
            string[] tokens = text.Split(' ', ',', '.', '!', '-', '?');

            IDictionary<string,int> words = new SortedDictionary<string, int>();

            foreach (string word in tokens) 
            { 
                if(!String.IsNullOrEmpty(word.Trim()))
                {
                    int count;

                    if(words.TryGetValue(word, out count))
                    {
                        count = 0;
                    }

                    words[word] = count + 1;
                }
            }

            return words;
        }

        private static void PrintWordOccurrenceMapCount(IDictionary<String, int> wordOccurrenceMap)
        {
            foreach(var wordEntry in wordOccurrenceMap)
            {
                Console.WriteLine("Word '{0}' occurs {0} times in the text", wordEntry.Key, wordEntry.Value);
            }
        }
    }
}
