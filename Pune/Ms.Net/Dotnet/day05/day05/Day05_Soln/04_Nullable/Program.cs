namespace _04_Nullable
{
    internal class Program
    {
        class Emp
        {
            int empno;
            string ename;
            string job;
            int? mgr; // mgr value may be null
            DateTime hire;
            double sal;
            double? comm; // comm value may be null
            int deptno;
            // ....
        }
        static void Main1(string[] args)
        {
            //Emp data --> empno, ename, job, mgr, hire, sal, comm, deptno
            //  in database -- KING's mgr --> NULL
            //  in database -- non-salesman emp's comm --> NULL

            // Nullable types -- where value type can have null value.
            Nullable<int> n1 = null; // = 12;
            if(n1.HasValue)
                Console.WriteLine("n1 value = " + n1);
            else
                Console.WriteLine("n1 has NO value");

            // int? is shorthand syntax for Nullable<int>
            int? n2 = null; // = 34;
            if (n2.HasValue)
                Console.WriteLine("n2 value = " + n2);
            else
                Console.WriteLine("n2 has NO value");
        }

        static void Main2(string[] args)
        {
            string str = "Sunbeam"; // should not be null
            //string? str = null; // may be null
            Console.WriteLine("Original String: " + str);
            if(str != null)
                Console.WriteLine("Upper Case: " + str.ToUpper());
            Console.WriteLine("Upper Case: " + str?.ToUpper());
        }

        static void Main(string[] args)
        {
            // null coalesce operator -- use first non-null value
            //string? userName = "Nilesh";
            string? userName = null;
            //string? guestName = "Guest";
            string? guestName = null;
            string? displayName = "User";
            Console.WriteLine("Hello, " + (userName ?? guestName));
            Console.WriteLine("Hello, " + (userName ?? guestName ?? displayName));
        }
    }
}
