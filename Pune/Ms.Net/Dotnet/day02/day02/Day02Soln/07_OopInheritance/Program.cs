using System.Xml.Linq;

namespace _07_OopInheritance
{
    class Emp : Person
    {
        public int Id { get; set; }
        public double Salary { get; set; }

        public Emp():this("", 0, 0, 0.0)
        {
        }
        public Emp(string name, int age, int id, double salary):base(name, age)
        {
            this.Id = id;
            this.Salary = salary;
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Emp: Id={this.Id}, Salary={this.Salary}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("P1", 20);
            p1.Display();
            Console.WriteLine();

            Emp e1 = new Emp("E1", 22, 1, 30000.0);
            e1.Display();
            Console.WriteLine();

            Person p2 = new Emp("E2", 24, 2, 40000.0);
            p2.Display();
            Console.WriteLine();
        }
    }
}
