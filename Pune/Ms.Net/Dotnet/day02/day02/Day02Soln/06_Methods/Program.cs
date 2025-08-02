namespace _06_Methods
{
    class MyInt
    {
        public int Num { get; set; }
    }
    internal class Program
    {
        public static void Swap1(int x, int y)
        {   // usual params are like IN params
            // any changes done will not reflect in calling fn
            int t = x;
            x = y;
            y = t;
            Console.WriteLine($"In Swap1: x = {x}, y = {y}");
        }
        public static void Swap2(MyInt x, MyInt y)
        {
            int t = x.Num;
            x.Num = y.Num;
            y.Num = t;
            Console.WriteLine($"In Swap2: x = {x.Num}, y = {y.Num}");
        }
        public static void Swap3(ref int x, ref int y)
        {   // ref is like IN-OUT param
            int t = x;
            x = y;
            y = t;
            Console.WriteLine($"In Swap3: x = {x}, y = {y}");
        }
        public static bool Divide(int x, int y, out double result)
        {
            // result is out param -- must be initialized by called fn
            //  may not be intialized by calling fn
            if (y != 0)
            {
                result = (double)x / y;
                return true;
            }
            result = 0;
            return false;
        }
        static void Main1(string[] args)
        {
            int n1 = 10, n2 = 20;
            // int (value types) are passed by value -- copy is created
            // any changes done in called fn are not reflected in calling fn
            Console.WriteLine($"Before Swap: n1 = {n1}, n2 = {n2}");
            Swap1(n1, n2);
            Console.WriteLine($"After Swap: n1 = {n1}, n2 = {n2}");
            Console.WriteLine();

            // MyInt (class - ref types) are passed by reference -- addr is passed
            // any changes done (in obj state) in called fn are reflected in calling fn
            MyInt n3 = new MyInt() { Num = 11 }, n4 = new MyInt() { Num = 22 };
            Console.WriteLine($"Before Swap: n3 = {n3.Num}, n4 = {n4.Num}");
            Swap2(n3, n4);
            Console.WriteLine($"After Swap: n3 = {n3.Num}, n4 = {n4.Num}");
            Console.WriteLine();

            int n5 = 10, n6 = 20;
            // int (value types) are passed by value -- copy is created
            // any changes done in called fn are not reflected in calling fn
            Console.WriteLine($"Before Swap: n5 = {n5}, n6 = {n6}");
            Swap3(ref n5, ref n6);
            Console.WriteLine($"After Swap: n5 = {n5}, n6 = {n6}");
            Console.WriteLine();
        }

        public static void Main2(string[] args) {
            int num1 = 22, num2 = 7;
            double result;
            if(Divide(num1, num2, out result))
                Console.WriteLine("Result = " + result);
            else
                Console.WriteLine("No Result");
        }

        static void Main(string[] args)
        {
            string greet = "Hello";
            // local methods (method inside another method)
            void PrintInfo(string name, int age, string addr="anywhere", string email="unknown")
            {
                // local methods can capture the variables of the outer method - Closure
                // static local method cannot capture the variables of outer method
                Console.WriteLine($"{greet} -> Name: {name}, Age: {age}, Addr: {addr}, Email: {email}");
            }
            // call the method -- using positional args (seq of args compulsory)
            PrintInfo("James Bond", 65, "London", "james@bond.com");
            // call the method -- using named args (seq is not compulsory)
            PrintInfo(age: 65, name: "James Bond", email: "james@bond.com", addr: "London");
            // call the method -- passing optional params is not compusory
            PrintInfo("James Bond", 65);
        }
    }
}
