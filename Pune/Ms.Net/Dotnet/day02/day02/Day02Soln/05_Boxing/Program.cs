using System.Collections;
using System.Threading.Channels;

namespace _05_Boxing
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            int num1 = 123;

            object obj = num1;
            // up-casting
            // int (value type) --> object (reference type) = Boxing

            int num2 = (int)obj;
            // down-casting
            // object (reference type) --> int (value type) = Unboxing
        }
        static void Main(string[] args)
        {
            int num = 123;
            Console.WriteLine("num = " + num); // num -> Boxing --> num.ToString()
            Console.WriteLine("num = {0}", num); // num -> Boxing

            // ArrayList is non-generic collection
            ArrayList list1 = new ArrayList();
            list1.Add(1); // Boxing 1 (int) --> object
            list1.Add(2); // Boxing 2 (int) --> object
            list1.Add(3); // Boxing 3 (int) --> object
            foreach (int i in list1) // Unboxing object --> int i
                Console.WriteLine("list1 elem: " + i);
            
            // List is generic collection
            List<int> list2 = new List<int>();
            list2.Add(1); // No Boxing
            list2.Add(2);
            list2.Add(3);
            foreach(int i in list2)
                Console.WriteLine("list2 elem: " + i);
        }
    }
}
