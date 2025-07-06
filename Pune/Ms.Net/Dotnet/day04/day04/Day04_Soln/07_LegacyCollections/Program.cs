using System.Collections;

namespace _07_LegacyCollections
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            // flexible - can store any type - object
            // grow/shrink at runtime
            // internally -- dynamically growing array
            // fast index-based access
            ArrayList arr = new ArrayList();
            Console.WriteLine("Initial Capacity: " + arr.Capacity);
            arr.Add(123);
            arr.Add(3.14);
            arr.Add("string");
            arr.Add(DateTime.Now);
            arr.Add(true);
            Console.WriteLine("Element Count: " + arr.Count);
            Console.WriteLine("Modified Capacity: " + arr.Capacity);
            // to access each elem (and their methods) -- need to downcast
            foreach (object obj in arr)
            {
                if (obj is int i)
                    Console.WriteLine("int elem = " + i);
                else if (obj is double d)
                    Console.WriteLine("double elem = " + d);
                else if (obj is string s)
                    Console.WriteLine("string elem = " + s);
                else if (obj is DateTime dt)
                    Console.WriteLine("datetime elem = " + dt);
                else
                    Console.WriteLine("unknown type elem = " + obj);
            }
        }
        // Hashtable -- Key-value pair -- Fast searching by Key

        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            ht.Add(12, "Nilesh");
            ht.Add(43, "Nitin");
            ht.Add(76, "Prashant");
            //ht.Add(12, "Rahul"); // System.ArgumentException: Item has already been added. Key in dictionary: '12'
            ht.Add(35, "Sameer");
            ht.Add(59, "Rahul");
            Console.Write("Enter roll: ");
            int roll = Convert.ToInt32(Console.ReadLine());
            string name = (string)ht[roll];
                // if found, returns value; otherwise return null
            Console.WriteLine("Student Found: " + name);
        }
    }
}
