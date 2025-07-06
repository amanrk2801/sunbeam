using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemo
{
    class Person
    {
        // fields
        private int age;
        private string name;
        private string addr;
        // constructors
        public Person() : this(0, "", "")
        {
            // if not initialized explicitly,
            // the fields will have default values of respective types.
            // e.g. age - int (0), name - string (null), addr - string (null)
        }
        public Person(int age, string name, string addr)
        {
            this.age = age;
            this.name = name;
            this.addr = addr;
        }
        // methods - facilitators
        public void Accept()
        {
            Console.Write("Enter Age: ");
            string ageStr = Console.ReadLine();
            this.age = int.Parse(ageStr);
            Console.Write("Enter Name: ");
            this.name = Console.ReadLine();
            Console.Write("Enter Addr: ");
            this.addr = Console.ReadLine();
        }
        public void Display()
        {
            //Console.WriteLine("Name: " + this.name + ", Age: " + this.age + ", Addr: " + this.addr);
            //Console.WriteLine("Name: {0}, Age: {1}, Addr: {2}", this.name, this.age, this.addr);
            Console.WriteLine($"Name: {this.name}, Age: {this.age}, Addr: {this.addr}");
        }
        // methods - getters/setters
        public void SetAge(int value)
        {
            age = value;
        }
        public int GetAge()
        {
            return age;
        }
        // create getter/setter for name and age
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Display();

            Person p2 = new Person(65, "James Bond", "London");
            p2.Display();

            Person p3 = new Person();
            p3.Accept();
            p3.Display();
        }
    }
}
