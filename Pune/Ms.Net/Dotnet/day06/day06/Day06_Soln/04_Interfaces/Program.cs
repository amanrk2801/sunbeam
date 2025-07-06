namespace _04_Interfaces
{
    public interface ILogger
    {
        void Log(string message);
        void LogError(string message)
        {
            Console.WriteLine("ERROR:" + message);
        }
    }
    public class ConsoleLogger : ILogger
    {
        public void Log(string message) {
            Console.WriteLine(message);
        }
    }

    interface IA
    {
        void Fun()
        {
            Console.WriteLine("IA.Fun() called.");
        }
    }
    interface IB:IA
    {
        void IA.Fun()
        {
            Console.WriteLine("IB.Fun() called.");
        }
    }
    interface IC : IA
    {
        void IA.Fun()
        {
            Console.WriteLine("IC.Fun() called.");
        }
    }
    class Derived : IB, IC
    {
        void IA.Fun()
        {
            Console.WriteLine("Derived.Fun() called.");
        }
    }
    internal class Program
    {
        static void Main1(string[] args)
        {
            ILogger logger1 = new ConsoleLogger();
            logger1.Log("First Line");
            logger1.LogError("Second Line"); // can be called on intf ref only

            ConsoleLogger logger2 = new ConsoleLogger();
            logger2.Log("Third Line");
            //logger2.LogError("..."); // Compiler Error
        }
        static void Main(string[] args)
        {
            IA obj = new Derived();
            obj.Fun(); // Derived.Fun() called.
        }
    }
}
