using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_OopInheritance
{
    internal class Person
    {
        public string Name {  get; set; }
        public int Age { get; set; }

        public Person() : this("", 0)
        {
        }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public virtual void Display()
        {
            Console.WriteLine($"Person: Name={this.Name}, Age={this.Age}");
        }
    }
}
