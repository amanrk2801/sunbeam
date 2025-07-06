using System.Runtime.CompilerServices;
using System.Text;
using static System.Console;

namespace _02_Static
{
    sealed class MyClass
    {
        public const double PI = 3.142; // const field cannot be static
        public static readonly int _readonlyField; // = 10;
                                                   // no access specifier - for static constructor
                                                   // no overloading -- static ctor
        public int field = 123;
        static MyClass()
        {
            _readonlyField = 1; // 
            Console.WriteLine("MyClass is Loaded -- static ctor() executing...");
        }
        public static void Fun()
        {
            Console.WriteLine("MyClass.Fun() called.");
        }
    }

    static class MyClassUtil
    {
        // extension method of the MyClass
        // rule 1: the first arg must be object of MyClass with "this" keyword
        // rule 2: must be static method of the static class (top-level)
        public static void Display(this MyClass obj)
        {
            Console.WriteLine("MyClass.Display() called: " + obj.field);
        }
    }

    // Common Practice: Utility extension methods are added into static helper classes
    //  and a separate class library is created -- which can be reused in multiple projects.
    static class StringUtils
    {
        public static string SwapCase(this string s)
        {
            StringBuilder sb = new StringBuilder(s.Length);
            foreach (char c in s)
            {
                if (Char.IsUpper(c))
                    sb.Append(Char.ToLower(c));
                else if (Char.IsLower(c))
                    sb.Append(Char.ToUpper(c));
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }

    interface IAddable<T> where T : IAddable<T>
    {
        abstract static T operator +(T v1, T v2);
    }

    // operator overloading in C# class/struct
    //  - must be static method named as operator(sign).
    //  - number of args must be as per the operator requirement i.e. unary, binary.
    //  - not all operators can be overloaded.
    class Vector : IAddable<Vector>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public static Vector operator +(Vector v1, Vector v2)
        {
            Vector res = new Vector()
            {
                X = v1.X + v2.X,
                Y = v1.Y + v2.Y
            };
            return res;
        }
        public static bool operator ==(Vector v1, Vector v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y;
        }
        // == operator must be overloaded with != operator
        public static bool operator !=(Vector v1, Vector v2)
        {
            return !(v1 == v2);
        }
        public override string ToString()
        {
            return $"[{X},{Y}]";
        }
    }
    internal static class ModuleInit
    {
        // method auto-executed when assembly is loaded in CLR for first time.
        [ModuleInitializer]
        public static void Initialize()
        {
            // Runs when assembly loads
            Console.WriteLine("Module initialized");
        }
    }
    internal class Program
    {
        static void Main1(string[] args)
        {
            MyClass obj = new MyClass();
            //obj.Fun(); // static methods cannot be accessed on object
            //MyClass.Fun();
        }
        static void Main2(string[] args)
        {
            // Extension methods
            MyClass obj = new MyClass();
            MyClassUtil.Display(obj);
            obj.Display();
            // internally calls --> MyClassUtil.Display(obj);

            string str = "SunBeam InfoTech";
            Console.WriteLine("String: " + str);
            Console.WriteLine("Toggle Case: " + str.SwapCase());
            //str.IsValidMobile(); // true/false -- homework
        }
        static void Main3(string[] args)
        {
            Vector a = new Vector() { X = 1, Y = 2 };
            Vector b = new Vector() { X = 3, Y = 4 };
            Vector c = a + b;
            //c = a - b; // need to oveload operator-() -- homework
            Console.WriteLine("c = " + c); // [4, 6]
            if (a == b)
                Console.WriteLine("a == b (same)");
            else
                Console.WriteLine("a != b (different)");
        }

        static void Main4(string[] args)
        {
            // top-level statement
            //  using static System.Console;
            WriteLine("Hello World!!");
        }
        static void Main(string[] args)
        {
            ConsoleLogger.Instance.Log("Hi, World!!");
            ConsoleLogger.Instance.Log("Bye, World!!");
            FileLogger.Instance.Log("Hi, World!!");
            FileLogger.Instance.Log("Bye, World!!");
        }
    }

    class ConsoleLogger
    {
        public void Log(string msg)
        {
            Console.WriteLine(DateTime.Now + ": " + msg);
        }
        private ConsoleLogger()
        { // private ctor -- no objects can be created outside the class
        }
        public static readonly ConsoleLogger Instance; // initialized only once.
        static ConsoleLogger()
        {
            // additional one time init logic
            Instance = new ConsoleLogger();
        }
    }
    class FileLogger
    {
        private string filePath;
        public void Log(string msg)
        {
            File.AppendAllText(filePath, DateTime.Now + ": " + msg + "\n");
        }
        private FileLogger()
        { // private ctor -- no objects can be created outside the class
        }
        public static readonly FileLogger Instance; // initialized only once.
        static FileLogger()
        {
            // additional one time init logic
            Instance = new FileLogger();
            Instance.filePath = "log.txt";
        }
    }
}
