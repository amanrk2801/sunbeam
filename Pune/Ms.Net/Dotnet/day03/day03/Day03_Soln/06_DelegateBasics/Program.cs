namespace _06_DelegateBasics
{
    delegate void MathOp(int x, int y); // delegate type declaration
    class MyMath
    {
        // static method
        public static void Sum(int x, int y)
        {
            Console.WriteLine($"Sum: {x} + {y} = {x + y}");
        }
        // non-static method
        public void Subtract(int x, int y)
        {
            Console.WriteLine($"Subtract: {x} - {y} = {x - y}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // local function
            void Multiply(int x, int y)
            {
                Console.WriteLine($"Multiply: {x} * {y} = {x * y}");
            }

            // local function
            void Divide(int x, int y)
            {
                Console.WriteLine($"Divide: {x} / {y} = {(double)x / y}");
            }

            // create delegate object and initialize it
            MathOp ptr1 = new MathOp(MyMath.Sum);

            MyMath obj = new MyMath();
            MathOp ptr2 = new MathOp(obj.Subtract);

            MathOp ptr3 = new MathOp(Multiply);

            MathOp ptr4 = Divide; // simplified syntax - implicit conv from fn to delegate

            // fn defn + delegate obj initialization = anonymous methods
            MathOp ptr5 = delegate (int x, int y)
            {
                Console.WriteLine($"Modulus: {x} % {y} = {x % y}");
                // as return type is "void", no return statement written.
            };

            // lambda expression -- multi-line statement syntax
            MathOp ptr6 = (x, y) =>
            {
                int result = (int)Math.Pow(x, y);
                Console.WriteLine($"Power: {x} ^ {y} = {result}");
                // as return type is "void", no return statement written.
            };

            // lambda expression -- single-line syntax (expr bodied syntax)
            MathOp ptr7 = (x, y) => Console.WriteLine($"Max({x}, {y}) = {int.Max(x, y)}");
            // internally  does new MathOp(Divide);

            // invoke the method
            /*
            ptr1(22, 7);
            ptr2(22, 7);
            ptr3(22, 7);
            ptr4(22, 7);
            ptr5(22, 7);
            ptr6(2, 5);
            ptr7(22, 7);
            */

            // multi-cast delegate = collection of delegates (fn pointers)
            MathOp ptr = ptr1;
            ptr += ptr2;
            ptr += ptr3;
            ptr += ptr4;
            ptr += (x,y) => Console.WriteLine($"Min({x}, {y}) = {int.Min(x, y)}");

            ptr(22, 7); // calls each delegate from the collection
        }
    }
}
