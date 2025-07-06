using System.Collections.Immutable;

namespace _01_Collections
{
    class Person : IEquatable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Addr { get; set; }
        public override bool Equals(object? obj)
        {
            Person other = obj as Person;
            if(other == null) return false;
            return this.Equals(other);
        }
        public bool Equals(Person? other)
        {
            return this.Name.Equals(other.Name);
        }
        public override string ToString()
        {
            return $"Person: Name={Name}, Age={Age}, Addr={Addr}";
        }
    }

    internal class Program
    {
        static void Main1(string[] args)
        {
            // Generic Lists
            List<int> list = new List<int>();
            list.Add(11);
            list.Add(22);
            list.Add(33);
            list.Add(44);
            list.Add(55);
            //list.Add("66"); // Compiler Error - Type Safety

            Console.WriteLine("Index Based List Traversal: ");
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine("list[i] = " + list[i]);

            Console.WriteLine("\nEnumeration Based List Traversal: ");
            IEnumerator<int> en = list.GetEnumerator();
            while (en.MoveNext())
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
        static void Main2(string[] args)
        {
            // Collection Initializer
            List<Person> list = new()
            {
                new Person() { Name = "James Bond", Age = 65, Addr = "London" },
                new Person() { Name = "Superman", Age = 87, Addr = "Crypton" },
                new Person() { Name = "Batman", Age = 45, Addr = "Gotham" }
            };
            list.Add(new Person() { Name = "Ironman", Age = 50, Addr = "NewYork" });

            Console.WriteLine("List traversal using foreach: ");
            // Traverse collection
            foreach (Person person in list)
            {
                Console.WriteLine(person);
                //list.Remove(person); // System.InvalidOperationException: Collection was modified;
                // while enumeerating through collection, if collection is modified --> InvalidOperationException
            }

            // for fail-safe iteration, traverse over the snapshot (copy) e.g.
            //  foreach (Person person in list.ToList()) { ... }

            // alternative approach -- use index-based traversal (instead of Enumeration).
            Console.WriteLine("\nList traversal using for loop: ");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
                if(i==2)
                    list.RemoveAt(i);
            }
        }
        static void Main3(string[] args)
        {
            // List<> allows duplicate elements.
            // HashSet<> keeps unique elements only.
            HashSet<string> set = new() { "One", "Two", "Three", "Four" };
            set.Add("Two");
            set.Add("Four");
            set.Add("Five");
            Console.WriteLine("Set Count: " + set.Count);

            Console.WriteLine("Set Elems: " + string.Join(",", set));
        }
        static void Main4(string[] args)
        {
            // Stack<> - LIFO -- O(1) time complexity
            Stack<int> s = new Stack<int>();
            s.Push(10);
            s.Push(20);
            s.Push(30);
            s.Push(40);
            Console.WriteLine("Stack Topmost Element: " + s.Peek()); // 40
            while (s.Count > 0)
            {
                int val = s.Pop();
                Console.WriteLine("Popped: " + val); // 40
            }
        }
        static void Main5(string[] args)
        {
            // Queue<> -- FIFO -- O(1) time complexity
            Queue<int> q = new Queue<int>();
            q.Enqueue(10);
            q.Enqueue(20);
            q.Enqueue(30);
            q.Enqueue(40);
            Console.WriteLine("Queue Count: " + q.Count);
            Console.WriteLine("Queue Topmost Element: " + q.Peek());
            while (q.Count > 0)
            {
                int val = q.Dequeue();
                Console.WriteLine("Popped: " + val);
            }
        }
        static void Main(string[] args)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("Nilesh", "9527331338");
            map.Add("Nitin", "9881208115");
            map.Add("Prashant", "9881208114");
            //map.Add("Nilesh", "3892423934"); // System.ArgumentException: An item with the same key has already been added. Key: Nilesh
            map["Nilesh"] = "9384798343"; // modify value for the key
            map["Vishal"] = "8932479823";

            //map.Remove("Nitin"); // deletes key-value pair

            string value = "";
            Console.Write("Enter Name: ");
            string key = Console.ReadLine();
            //value = map[key]; // System.Collections.Generic.KeyNotFoundException if key not found
            //Console.WriteLine("Mobile: " + value);

            if(map.TryGetValue(key, out value))
                Console.WriteLine("Mobile: " + value);
            else
                Console.WriteLine("Not Found.");

            // traverse the dictionary
            foreach(KeyValuePair<string,string> item in map)
            {
                Console.WriteLine(item);
            }
        }

        static void Main7(string[] args)
        {
            // LinkedList<> preferred for sequential traversal and frequent add/remove in middle.
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);
            list.AddLast(40);
            Console.WriteLine("List: " + string.Join(", ", list));
            list.AddFirst(50);
            Console.WriteLine("List: " + string.Join(", ", list));

            // traverse linked list with index -- not possible
            for (int i = 0; i < list.Count; i++)
            {
                //Console.WriteLine(list[i]); // cannot have index based access using indexer.
            }
        }

        static void Main8(string[] args)
        {
            // Create an immutable list
            ImmutableList<string> colors = ImmutableList.Create("Red", "Green", "Blue");
            // Iterate and print the original list
            Console.WriteLine("Original List:");
            foreach (var color in colors)
                Console.WriteLine(color);
            // Create a new list by adding an item
            ImmutableList<string> newColors = colors.Add("Orange");
            // Print the new list
            Console.WriteLine("\nNew List (with Orange added):");
            foreach (var color in newColors)
                Console.WriteLine(color);

            Console.WriteLine("\nOriginal List: Not Modified.");
            foreach (var color in colors)
                Console.WriteLine(color);
        }
    }
}
