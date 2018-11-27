using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryCollections
{
    class Program
    {

        public class Elements{
            public string Symbol { get; set; }
            public string Name { get; set; }
            public int AtomicNumber { get; set; }

        }
        static void Main(string[] args)
        {

            Dictionary<string, Elements> elements = BuildDictionary();

            //LINQ example
            var resultDict = from dict in elements
                             where dict.Key == "K"
                             select dict;

            foreach (var some in resultDict) {
                Console.WriteLine("Result from query" + some.Value.Name);

            }
            Console.WriteLine("Element at index 1 is " + elements.ElementAt(1));
            Console.WriteLine(" The first elemetn is " + elements.First());
            Console.WriteLine(elements.LongCount());
            //elements.Max<>
            

            Display(elements);
            FindInDictionary("K", elements);
            FindInDictionary2("S", elements);
            RemoveEle(elements,"K");
            Display(elements);
        }

        private static Dictionary<string,Elements> BuildDictionary() {

            var elements = new Dictionary<string, Elements>();
            AddToDictionary(elements, "K", "Potassium", 19);
            AddToDictionary(elements, "Ca", "Calcium", 20);
            AddToDictionary(elements, "Sc", "Scandium", 21);
            AddToDictionary(elements, "Ti", "Titanium", 22);

            return elements;

            }

        private static void AddToDictionary(Dictionary<String, Elements> d, String s, string name, Int32 atomicNum) {
            Elements theElement = new Elements();
            theElement.Symbol = s;
            theElement.Name = name;
            theElement.AtomicNumber = atomicNum;
            d.Add(theElement.Symbol, theElement);

            }

        private static void Display(Dictionary<string, Elements> d) {
            foreach(KeyValuePair<string ,Elements> kvp in d ){
                Elements temp = kvp.Value;
                Console.WriteLine(kvp.Key + " :" + temp.Name + "" + temp.Symbol + "" + temp.AtomicNumber);
                    }
            }

        private static void RemoveEle(Dictionary<string, Elements> d, string key) {
            if (d.ContainsKey(key)) {
                    if (d.Remove(key)) {
                        Console.WriteLine(key + " removed !");
                            }
            }
            
            }
        //The following example uses the ContainsKey method and the Item[TKey] property of Dictionary to quickly find an item by key.The Item property enables you to access an item in the elements collection by using the elements[symbol] in C#.

        private static void FindInDictionary(string symbol, Dictionary<string, Elements> d)
        {
            if (d.ContainsKey(symbol) == false)
            {
                Console.WriteLine(symbol + " not found");
            }
            else
            {
                Console.WriteLine("found element " + d[symbol].Name + " " + d[symbol].Symbol +" " + d[symbol].AtomicNumber);
            }
        }
        //The following example instead uses the TryGetValue method quickly find an item by key.
        private static void FindInDictionary2(string symbol, Dictionary<string, Elements> d)
        {
           // Elements theElement = null;
            if (d.TryGetValue(symbol, out Elements theElement) == false)
                Console.WriteLine(symbol + " not found");
            else
                Console.WriteLine("found: " + theElement.Name);
        }
    }
}
