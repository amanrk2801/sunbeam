using System.Collections;

namespace _08_GenericCollections
{
    internal class Program
    {
        // List<> - Generic collection
        //  Internally Dynamic Array - Grow/Shrink at Runtime
        //  Indexed-Based - Fast access
        //  Sequential Traversal - IEnumeration (foreach loop) 
        static void Main1(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(11);
            list.Add(22);
            list.Add(33);
            list.Add(44);
            list.Add(55);
            //list.Add("66"); // Compiler Error - Type Safety
            
            Console.WriteLine("Index Based List Traversal: ");
            for(int i=0; i<list.Count; i++)
                Console.WriteLine("list[i] = " + list[i]);
            
            Console.WriteLine("\nEnumeration Based List Traversal: ");
            IEnumerator<int> en = list.GetEnumerator();
            while(en.MoveNext())
            {
                int elem = en.Current;
                Console.WriteLine("elem = " + elem);
            }

            Console.WriteLine("\nforeach Based List Traversal: ");
            foreach (int elem in list)
                Console.WriteLine("elem = " + elem);

            Console.WriteLine("\nForEach() Based List Traversal: ");
            list.ForEach(e => Console.WriteLine("ForEach elem = " + e));

            // Searching -- Linear Search -- Loop through all elems and match with Key
            
            Console.WriteLine("\nGet Even Numbers using Where() method");
            IEnumerable<int> evenList = list.Where(x => x % 2 == 0);
            foreach (int elem in evenList)
                Console.WriteLine("Even Elem: " + elem);
        }

        static void Main(string[] args)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(11, "Nilesh");
            // ...

        }
    }
}
