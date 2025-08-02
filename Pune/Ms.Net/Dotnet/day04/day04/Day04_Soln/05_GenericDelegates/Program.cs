namespace _05_GenericDelegates
{
    // user-defined generic delegates
    delegate void Consumer<T>(T obj);   // like Java Consumer
    delegate T Supplier<T>();           // like Java Supplier
    delegate R Function<T, R>(T obj);   // like Java Function
    delegate bool Condition<T>(T obj);  // like Java Predicate
    internal class Program
    {
        // demo of user defined generic delegates
        static void Main1(string[] args)
        {
            #region Consumer<> demo
            Consumer<string> print = Console.WriteLine;
            // Console class -> static void WriteLine(string line);
            print("Hello, World!");
            #endregion

            #region Supplier<> demo
            int RandomInt()
            {
                Random r = new Random();
                return r.Next(100);
            }
            Supplier<int> random = RandomInt;
            Console.WriteLine("Random Num: " + random());
            #endregion

            #region Function<> demo
            Function<string, int> convert = int.Parse;
            int num = convert("123");
            Console.WriteLine("Num : " + num);
            #endregion

            #region Condition<> demo
            Condition<int> IsEven = x => x % 2 == 0;
            int number = 123;
            Console.WriteLine($"IsEven {number} -> " + IsEven(number));
            #endregion
        }

        // demo of "built-in" generic delegates
            // delegate void Action<T>(T obj);
            // delegate R Func<T,R>(T obj);
            // delegate R Func<R>();
            // delegate bool Predicate<T>(T obj);
        static void Main(string[] args)
        {
            Action<string> print = Console.WriteLine;
            print("Hello, World!");

            Func<int> random = () => new Random().Next(100);
            print("Random Int: " + random());

            Func<string,int> convert = int.Parse;
            Console.WriteLine("Num : " + convert("123"));

            Predicate<int> IsEven = (x) => x % 2 == 0;
            Console.WriteLine("Is Even : " + IsEven(123));

            Func<int,bool> IsOdd = x => x % 2 != 0;
            Console.WriteLine("Is Odd : " + IsOdd(123));
        }
    }
}
