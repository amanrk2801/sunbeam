using MathLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLib;

namespace MathClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Object can be created using fully qualified class name
            //  NamespaceName.ClassName
            //MathLib.MyMath obj = new MathLib.MyMath(); 

            // Alternatively namespace can be imported ("using" keyword).
            //  then use ClassName directly.
            MyMath obj = new MyMath();
            int num1, num2, result;
            num1 = 22;
            num2 = 7;
            result = obj.Multiply(num1, num2);
            Console.WriteLine("Result: " + result);
        }
    }
}
