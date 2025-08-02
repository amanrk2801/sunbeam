namespace _05_Generics
{
    internal class Program
    {
        // non-generic class
        class ObjBox
        {
            private object obj;
            public object Get() { return obj; }
            public void Set(object obj) { this.obj = obj; }
        }
        static void Main1(string[] args)
        {
            ObjBox b1 = new ObjBox();
            b1.Set("Secret"); // String
            string val = (string)b1.Get();
            //DateTime val = (DateTime)b1.Get(); // System.InvalidCastException: Unable to cast object of type 'System.String' to type 'System.DateTime
            Console.WriteLine("b1 val: " + val);
        }

        class Box<T>
        {
            private T obj;
            public T Get() { return obj; }
            public void Set(T obj) { this.obj = obj; }
            public void Display()
            {
                Console.WriteLine(obj); // non-generic method
            }
        }
        static void Main2(string[] args)
        {
            Box<string> b1 = new Box<string>();
            b1.Set("Secret");
            //DateTime val = (DateTime)b1.Get(); // Compiler ERROR: Cannot convert type 'string' to 'System.DateTime'
            string val = b1.Get();
            Console.WriteLine("b1 val: " + val);

            //Box<Emp> b = new Box<Emp>(); // Emp class

            Box<int> b2 = new Box<int>();
            b2.Set(123);                        // No Boxing
            int val2 = b2.Get();                // No Unboxing
            Console.WriteLine("b2 val: " + val2);

            Box<double> b3 = new Box<double>();
            b3.Set(3.142);                        // No Boxing
            double val3 = b3.Get();                // No Unboxing
            Console.WriteLine("b3 val: " + val3);
        }

        static void Swap<T>(ref T a, ref T b)
        {
            T t = a; a = b; b = t;
        }
        static void Main3(string[] args)
        {
            int n1 = 11, n2 = 22;
            Console.WriteLine($"Before Swap: n1 = {n1}, n2 = {n2}");
            Swap<int>(ref n1, ref n2);
            Console.WriteLine($"After Swap: n1 = {n1}, n2 = {n2}");

            double n3 = 1.1, n4 = 2.2;
            Console.WriteLine($"Before Swap: n3 = {n3}, n4 = {n4}");
            Swap(ref n3, ref n4); // gen type is inferred based on args passed
            Console.WriteLine($"After Swap: n3 = {n3}, n4 = {n4}");

            string s1 = "Str1", s2 = "Str2";
            Console.WriteLine($"Before Swap: s1 = {s1}, s2 = {s2}");
            Swap(ref s1, ref s2);
            Console.WriteLine($"After Swap: s1 = {s1}, s2 = {s2}");
        }

        // non-generic class may have generic methods
        class Util
        {
            public void Swap<T>(ref T a, ref T b)
            {
                T t = a; a = b; b = t;
            }
        }
        static void Main4(string[] args)
        {
            string s1 = "Str1", s2 = "Str2";
            Console.WriteLine($"Before Swap: s1 = {s1}, s2 = {s2}");
            Util util = new Util();
            util.Swap(ref s1, ref s2);
            Console.WriteLine($"After Swap: s1 = {s1}, s2 = {s2}");
        }

        class Emp:IComparable<Emp>
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Salary { get; set; }

            public int CompareTo(Emp other)
            {
                if (other == null)
                    return 1;
                int diff = this.Id - other.Id;
                return diff;
            }
            public override string ToString()
            {
                return $"Emp: Id={this.Id}, Name={this.Name}, Salary: {this.Salary}";
            }
        }
        class EmpSalaryComparer : IComparer<Emp>
        {
            public int Compare(Emp x, Emp y)
            {
                int diff = double.Sign(x.Salary - y.Salary);
                return diff;
            }
        }
        static void Main5(string[] args)
        {
            // Built-in Generic interfaces -- IComparable<>, IComparer<T>
            Emp[] arr = new Emp[5]
            {
             new Emp { Id = 2, Name = "John", Salary = 2000.0 },
             new Emp { Id = 5, Name = "Mark", Salary = 1500.0 },
             new Emp { Id = 1, Name = "Steve", Salary = 3500.0 },
             new Emp { Id = 4, Name = "Peter", Salary = 4000.0 },
             new Emp { Id = 3, Name = "Tony", Salary = 3000.0 }
            };

            Console.WriteLine("Sort Emps by Id: ");
            Array.Sort(arr);
            // If Emp is not implementing IComparable<>
            //  -> System.ArgumentException: At least one object must implement IComparable.
            foreach (Emp emp in arr)
                Console.WriteLine(emp);

            Console.WriteLine("\nSort Emps by Salary:");
            Array.Sort(arr, new EmpSalaryComparer());
            foreach (Emp emp in arr)
                Console.WriteLine(emp);
        }

        class SomeClass
        {
            // ...
        }
        static void Main6(string[] args)
        {
            // Generic Constraints -- where T is inherited from IComparable
            static T GetMax<T>(T a, T b) where T : IComparable<T>
            {
                //return a > b ? a : b; // cannot use arithmetic/relative operators with gen type T
                int diff = a.CompareTo(b);
                return diff > 0 ? a : b;
            }

            string s1 = "ABC", s2 = "PQR";
            string maxStr = GetMax(s1, s2);
            Console.WriteLine("Max String: " + maxStr);

            // this also works with int, double, etc -- all these classes are IComparable<>
            Emp e1 = new Emp() { Id = 3, Name = "John", Salary = 2000.0 };
            Emp e2 = new Emp() { Id = 2, Name = "Dagny", Salary = 2500.0 };
            Emp maxEmp = GetMax(e1, e2);
            Console.WriteLine("Max Emp: " + maxEmp);

            SomeClass obj1 = new SomeClass();
            SomeClass obj2 = new SomeClass();
            //SomeClass maxObj = GetMax(obj1, obj2);
            //ERROR: The type '_05_Generics.Program.SomeClass' cannot be used as type parameter 'T' in the generic type or method 'GetMax<T>(T, T)'. There is no implicit reference conversion from '_05_Generics.Program.SomeClass' to 'System.IComparable<_05_Generics.Program.SomeClass>'.
        }

        // class without paramless ctor
        class Student
        {
            private int id;
            public Student(int id)
            {
                this.id = id;    
            }
        }
        static void Main(string[] args)
        {
            static T CreateObj<T>() where T : class, new()
            {
                T obj = new T();
                return obj;
            }

            Emp e = CreateObj<Emp>(); // Emp is class and Emp has paramless ctor (default)
            Console.WriteLine(e);

            //Student s = CreateObj<Student>(); // Error: cannot be used because Student doesn't have paramless ctor

            //int i = CreateObj<int>(); // Error: cannot be used with any value type
        }
    }
}
