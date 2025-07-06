namespace _01_Delegates
{
    delegate int MathRetOp(int x, int y);
    internal class Program
    {
        // Multicast delegate - Function returning value
        static void Main(string[] args)
        {
            int Add(int x, int y)
            {
                return x + y;
            }
            MathRetOp op = Add;
            op += delegate (int x, int y) { return x - y; };
            op += (x, y) => x * y;

            int res = op(22, 7);
            Console.WriteLine("Final Result: " + res);
            Console.WriteLine();

            foreach(MathRetOp fn in op.GetInvocationList())
            {
                int result = fn(22, 7);
                Console.WriteLine("Fn Result: " + result);
            }
        }
    }
}
