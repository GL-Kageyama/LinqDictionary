using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqDictionary
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var dictionaryClass = new DictionaryClass();

            dictionaryClass.GetDictItem();

            dictionaryClass.GetAllKey();

            dictionaryClass.newDictionary();

            dictionaryClass.DuplicateKey();

        }
    }

    class DictionaryClass
    {
        
        // Define the dictionary type
        Dictionary<string, int> flowerDict = new Dictionary<string, int>()
        {
            ["sunflower"] = 400,
            ["pansy"] = 300,
            ["tulip"] = 350,
            ["rose"] = 500,
            ["dahlia"] = 450,
        };

        public void GetDictItem()
        {
            // Output all
            foreach (var item in flowerDict)
                Console.WriteLine("{0} = {1}", item.Key, item.Value);
            Console.WriteLine();

            // Calculate the average
            var average = flowerDict.Average(x => x.Value);
            Console.WriteLine(average);
            Console.WriteLine();

            // Calculate the total
            var total = flowerDict.Sum(x => x.Value);
            Console.WriteLine(total);
            Console.WriteLine();

            // Outputs a Key of 5 characters or less
            var items = flowerDict.Where(x => x.Key.Length <= 5);
            foreach (var item in items)
                Console.WriteLine("{0} = {1}", item.Key, item.Value);
            Console.WriteLine();
        }

        // Extract all keys
        public void GetAllKey()
        {
            foreach (var key in flowerDict.Keys)
                Console.WriteLine(key);
            Console.WriteLine();
        }

        // Create a new dictionary type
        public void newDictionary()
        {
            var newDict = flowerDict.Where(x => x.Value >= 400)
                                    .ToDictionary(flower => flower.Key, flower => flower.Value);
            foreach (var item in newDict.Keys)
                Console.WriteLine(item);
            Console.WriteLine();
        }

        // Dictionary type to allow duplicate keys
        public void DuplicateKey()
        {
            // Multiple dictionary type
            var dict = new Dictionary<string, List<string>>()
            {
                { "PC", new List<string> {"Personal Computer", "Program Counter", } },
                { "CD", new List<string> {"Compact Disc", "Cash Dispenser", } },
            };

            // Add to dictionary type
            var key = "EC";
            var value = "Electronic Commerce";
            if (dict.ContainsKey(key)) {
                dict[key].Add(value);
            } else {
                dict[key] = new List<string> { value };
            }

            // Enumerate the contents of a dictionary type
            foreach (var item in dict)
            {
                foreach (var term in item.Value)
                {
                    Console.WriteLine("{0} : {1}", item.Key, term);
                }
            }
        }
    }
}