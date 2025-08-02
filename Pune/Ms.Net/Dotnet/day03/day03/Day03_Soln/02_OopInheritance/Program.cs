using System.Runtime.InteropServices.Marshalling;

namespace _02_OopInheritance
{
    abstract class Emp
    {
        public int Id { get; set; }
        public double Salary { get; set; }

        public virtual double CalcIncome()
        {
            return Salary;
        }
        public abstract void DoWork();
    }
    // static helper/utility class
    //  no object can be created
    //  all members must be static
    static class EmpUtil
    {
        public static double CalcTotalExpenses(Emp[] emps)
        {
            double totalExpense = 0.0;
            foreach (Emp e in emps)
                totalExpense += e.CalcIncome();
            return totalExpense;
        }
        // ... other helper methods ... static
    }
    class Labor : Emp
    {
        private int _hours, _rate;
        public int Hours { 
            get {
                return _hours;
            }
            set {
                _hours = value;
                this.Salary = _hours * _rate;
            }
        }
        public int Rate
        {
            get
            {
                return _rate;
            }
            set
            {
                _rate = value;
                this.Salary = _hours * _rate;
            }
        }
        public override void DoWork()
        {
            Console.WriteLine("Labor - Physical Work");
        }
    }
    class Manager : Emp
    {
        public double Bonus { get; set; }

        public sealed override double CalcIncome()
        {
            return this.Salary + this.Bonus;
        }
        public override void DoWork()
        {
            Console.WriteLine("Manager - Management Work");
        }
    }
    // Company Policy = any manager income = Salary + Bonus (no extra component)
    class SalesManager:Manager
    {
        //ERROR: 'SalesManager.CalcIncome()': cannot override inherited member 'Manager.CalcIncome()' because it is "sealed"
        //public override double CalcIncome() { }
    }
    class HRManager:Manager
    {
        // ...
    }
    class Salesman : Emp
    {
        public double Commission { get; set; }

        public override double CalcIncome()
        {
            return this.Salary + this.Commission;
        }
        public override void DoWork()
        {
            Console.WriteLine("Salesman - Sales Work");
        }
    }

    // Company Policy: No special type of Clerks
    //  sealed classes cannot be further inherited (no derived classes possible)
    //  effectively all methods in sealed class are sealed methods.
    sealed class Clerk : Emp
    {
        public override void DoWork()
        {
            Console.WriteLine("Salesman - Clerical Work");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Emp[] emps = new Emp[5];
            // array of 5 references created on heap
            // by default each ref is initialized to null
            //emps[0] = new Emp() { Id = 1, Salary = 2000.0 };
            // ERROR: Cannot create an instance of the abstract type or interface 'Emp'
            emps[0] = new Clerk() { Id = 1, Salary = 1500.0 };
            emps[1] = new Manager() { Id = 2, Salary = 2000.0, Bonus = 1000.0 };
            emps[2] = new Labor() { Id = 5, Hours = 30, Rate = 20 };
            emps[3] = new SalesManager() { Id = 3, Salary = 2500.0, Bonus = 600.0 };
            emps[4] = new Salesman() { Id = 4, Salary = 2000.0, Commission = 500.0 };

            //EmpUtil empUtil = new EmpUtil();
            // not expected to create the object of helper/utility class
            // ERROR: Cannot declare a variable of static type 'EmpUtil'

            double totalExpense = EmpUtil.CalcTotalExpenses(emps);
            Console.WriteLine("Total Expense: " + totalExpense);

            // display ids of all emps
            // display specialities (special members) of all emps
            //  e.g. Mananger - Bonus, Salesman - Commission, ...
            foreach (Emp e in emps)
            {
                Console.WriteLine($"{e.GetType()} Id: {e.Id}");
                // display Manager Bonus
                if(e is Manager) // type checking (return bool)
                {
                    // is operator - checks if given object is of the given type or its derived type
                    Manager m = (Manager)e; // type casting
                    Console.WriteLine($" - Bonus: {m.Bonus}");
                }
                // display Salesman Commission
                if(e is Salesman s) // type checking + type casting (return bool)
                {
                    Console.WriteLine($" - Commission: {s.Commission}");
                }
                // display Labor hours & rate
                Labor l = e as Labor; // type checking + type casting (return ref)
                    // if e points to Labor object, returns Labor ref
                    // otherwise return null ref
                if(l != null)
                {
                    Console.WriteLine($" - Hours: {l.Hours}, Rate: {l.Rate}");
                }
            }
        }
    }
}
