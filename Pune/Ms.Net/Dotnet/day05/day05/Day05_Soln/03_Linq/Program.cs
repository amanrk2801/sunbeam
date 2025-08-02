namespace _03_Linq
{
    public class Dept
    {
        public int DeptId { get; set; }
        public string Dname { get; set; }
        public string Location { get; set; }
    }
    //class MyClass
    //{
    //    var abc; // ERROR: var - only for local variables
    //}
    internal class Program
    {
        static void Main1(string[] args)
        {
            // var keyword - data type is inferred by compiler.
            //  application only for local variables
            var s = "Sunbeam"; // s is string
            s = "DAC";
            //s = 123; // ERROR: cannot assign int to string var
            var f = true; // f is bool
            var list = new List<string>(); // list is List<String>
            Console.WriteLine("s in upper case: " + s.ToUpper());
            Console.WriteLine("f: " + f);
            list.Add("India");
            list.Add("Nepal");
            foreach (var item in list)
                Console.WriteLine("Item: " + item);
            var d = new Dept { DeptId = 10, Dname = "ACCOUNTING", Location = "PUNE" };
            Console.WriteLine("d = " + d.Dname);

            // var must be initialized at declaration
            //var name; // ERROR: must be initialized at declaration
            //var obj = null; // ERROR: cannot be initialized to null
        }
        static void Main2(string[] args)
        {
            // anonymous type -- 
            //  can only hold data (fields) -- no methods
            //  
            var p1 = new { Name = "Nilesh", Age = 42, Addr = "Pune" };
            Console.WriteLine($"p1 members: Name={p1.Name}, Age={p1.Age}");
            Console.WriteLine("p1: " + p1); // ToString(), Equals(), HashCode() - auto-implemented

            // collection of anonymous type object
            var peopleArray = new[]
            {
                p1,
                new {Name="Nitin", Age=50, Addr="Satara"},
                new {Name="Prashant", Age=48, Addr="Karad"},
                //new {Name="John"} // only same schema obj can be added in array
            };
            Console.WriteLine("\nTraverse array of implicit type: ");
            foreach (var p in peopleArray)
                Console.WriteLine(p);

            var peopleList = new[]
            {
                new {Name="Nitin", Age=50, Addr="Satara"},
                new {Name="Prashant", Age=48, Addr="Karad"},
            }.ToList();

            Console.WriteLine("\npeopleList Type: " + peopleList.GetType());
            Console.WriteLine("\nTraverse list of implicit type: ");
            foreach (var p in peopleList)
                Console.WriteLine(p);
        }

        public class Emp
        {
            public int EmpId { get; set; }
            public string Ename { get; set; }
            public string Job { get; set; }
            public int? ManagerId { get; set; }
            public DateTime Hire { get; set; }
            public double Salary { get; set; }
            public double? Commission { get; set; }
            public int DeptId { get; set; }

            public override string ToString()
            {
                return $"Id: {EmpId}, Name: {Ename}, Job: {Job}, Manager: {ManagerId}, Hire: {Hire.ToShortDateString()}, Salary: {Salary}, Comm: {Commission}, Dept: {DeptId}";
            }
        }

        static void Main(string[] args)
        {
            // LINQ -- SQL like features in C# language
            //  LINQ can be used on Collections, XML, Database, etc.
            List<Emp> emps = new List<Emp>
            {
                new Emp { EmpId = 7369, Ename = "SMITH", Job = "CLERK", ManagerId = 7902, Hire = DateTime.Parse("1980-12-17"), Salary = 800.00, Commission = null, DeptId = 20 },
                new Emp { EmpId = 7499, Ename = "ALLEN", Job = "SALESMAN", ManagerId = 7698, Hire = DateTime.Parse("1981-02-20"), Salary = 1600.00, Commission = 300.00, DeptId = 30 },
                new Emp { EmpId = 7521, Ename = "WARD", Job = "SALESMAN", ManagerId = 7698, Hire = DateTime.Parse("1981-02-22"), Salary = 1250.00, Commission = 500.00, DeptId = 30 },
                new Emp { EmpId = 7566, Ename = "JONES", Job = "MANAGER", ManagerId = 7839, Hire = DateTime.Parse("1981-04-02"), Salary = 2975.00, Commission = null, DeptId = 20 },
                new Emp { EmpId = 7654, Ename = "MARTIN", Job = "SALESMAN", ManagerId = 7698, Hire = DateTime.Parse("1981-09-28"), Salary = 1250.00, Commission = 1400.00, DeptId = 30 },
                new Emp { EmpId = 7698, Ename = "BLAKE", Job = "MANAGER", ManagerId = 7839, Hire = DateTime.Parse("1981-05-01"), Salary = 2850.00, Commission = null, DeptId = 30 },
                new Emp { EmpId = 7782, Ename = "CLARK", Job = "MANAGER", ManagerId = 7839, Hire = DateTime.Parse("1981-06-09"), Salary = 2450.00, Commission = null, DeptId = 10 },
                new Emp { EmpId = 7788, Ename = "SCOTT", Job = "ANALYST", ManagerId = 7566, Hire = DateTime.Parse("1982-12-09"), Salary = 3000.00, Commission = null, DeptId = 20 },
                new Emp { EmpId = 7839, Ename = "KING", Job = "PRESIDENT", ManagerId = null, Hire = DateTime.Parse("1981-11-17"), Salary = 5000.00, Commission = null, DeptId = 10 },
                new Emp { EmpId = 7844, Ename = "TURNER", Job = "SALESMAN", ManagerId = 7698, Hire = DateTime.Parse("1981-09-08"), Salary = 1500.00, Commission = 0.00, DeptId = 30 },
                new Emp { EmpId = 7876, Ename = "ADAMS", Job = "CLERK", ManagerId = 7788, Hire = DateTime.Parse("1983-01-12"), Salary = 1100.00, Commission = null, DeptId = 20 },
                new Emp { EmpId = 7900, Ename = "JAMES", Job = "CLERK", ManagerId = 7698, Hire = DateTime.Parse("1981-12-03"), Salary = 950.00, Commission = null, DeptId = 30 },
                new Emp { EmpId = 7902, Ename = "FORD", Job = "ANALYST", ManagerId = 7566, Hire = DateTime.Parse("1981-12-03"), Salary = 3000.00, Commission = null, DeptId = 20 },
                new Emp { EmpId = 7934, Ename = "MILLER", Job = "CLERK", ManagerId = 7782, Hire = DateTime.Parse("1982-01-23"), Salary = 1300.00, Commission = null, DeptId = 10 }
            };
            Console.WriteLine("All Emps:");
            Display(emps);

            #region Linq Method Syntax -- Basic Linq Operator
            Console.WriteLine("\nEmps with Sal > 2000:");
            var result1 = emps.Where(e => e.Salary > 2000);
            Display(result1);

            Console.WriteLine("\nEmps Sorted by Dept & By Job:");
            var result2 = emps.OrderBy(e => e.DeptId).ThenBy(e => e.Job);
            Display(result2);

            var result3 = emps.Sum(e => e.Salary); // Average(), Max(), Min(), Count()
            Console.WriteLine("\nSum of Sal: " + result3);
            #endregion

            #region Linq Method Syntax vs Query Syntax
            // get all emps with sal > 2000 in sorted order of their name.
            Console.WriteLine("\nEmps with Sal > 2000 in Sorted Order of Name: ");
            var result4 = emps.Where(e => e.Salary > 2000).OrderBy(e => e.Ename);
            Display(result4);

            Console.WriteLine("\nEmps with Sal > 2000 in Sorted Order of Name: ");
            var result5 = from e in emps 
                          where e.Salary > 2000 
                          orderby e.Ename 
                          select e;
            Display(result5);

            Console.WriteLine("\nNames & Sals of all Emps in Dept 10");
            var result7 = from e in emps
                          where e.DeptId == 10
                          select new { Name = e.Ename, Sal = e.Salary };
            Display(result7);
            #endregion

            #region Linq Hybrid - Query + Method Syntax
            Console.WriteLine("\nTop 3 Emps w.r.t. Sal: ");
            var result6 = from e in emps
                          orderby e.Salary descending
                          select e;
            Display(result6.Take(3));
            var top3 = result6.Take(3).ToList(); // internally loops through result
            Console.WriteLine("Top 3 Count: " + top3.Count);
            #endregion

            List<Dept> depts = new List<Dept>
            {
                new Dept { DeptId = 10, Dname = "Accounting", Location = "New York" },
                new Dept { DeptId = 20, Dname = "Research", Location = "Dallas" },
                new Dept { DeptId = 30, Dname = "Sales", Location = "Chicago" },
                new Dept { DeptId = 40, Dname = "Operations", Location = "Boston" }
            };
            #region Linq Advanced - Join
            Console.WriteLine("\nEmps & Depts Joined ...");
            var result = from e in emps
                         join d in depts on e.DeptId equals d.DeptId
                         select new { EmpName = e.Ename, DeptName = d.Dname };
            Display(result);
            #endregion
        }
        public static void Display<T>(IEnumerable<T> en)
        {
            foreach (var e in en)
                Console.WriteLine(e);
        }
    }
}
