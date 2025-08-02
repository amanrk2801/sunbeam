using System.Runtime.CompilerServices;

namespace _03_DataTypes
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            string str = "123ABC";

            #region Type conversion using Parse() method
            int num1 = int.Parse(str);
            // int is converted to Int32 struct
            // Parse() is static method in struct
            // throw System.FormatException if input string is invalid
            Console.WriteLine($"num1 = {num1}");
            #endregion

            #region Type conversion using Convert class
            int num2 = Convert.ToInt32(str);
            // Convert class has plenty of static methods for converting
            //  any type to other type (commonly used for primitive type conv)
            // throw System.FormatException if input string is invalid
            Console.WriteLine($"num2 = {num2}");
            #endregion

        }

        static void Main(string[] args)
        {
            unchecked // default behaviour
            {
                // short range: -32768 to +32767
                short num1 = 32767;
                num1++; // overflow --> roll to opposite sign
                Console.WriteLine($"num1 = {num1}");
            }

            checked // check for arithmetic overflow (data type range)
            {       // and throw exeception if overflow
                short num2 = 32767;
                num2++; // System.OverflowException: Arithmetic operation resulted in an overflow.
                Console.WriteLine($"num2 = {num2}");
            }
        }
    }
}
