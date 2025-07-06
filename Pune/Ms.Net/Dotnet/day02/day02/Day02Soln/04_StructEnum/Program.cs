using System.ComponentModel.Design;

namespace _04_StructEnum
{
    // struct is ValueType -- advised only for the small records
    struct Point
    {
        // default access specifier is private
        private int x, y; // uninitialized fields are initialized to default values
        public Point()
        {
            this.x = 0;
            this.y = 0;
        }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int GetX() { return x; }
        public int GetY() { return y; }

        /*Properties*/
        /*smart implementation of getter/setter, so that they can be used like fields*/
        /*advantages: improves readability*/
        /*readonly property: only getter*/
        /*setters may have strict access specifier - in classes.*/
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }

    class Person
    {
        // convention - private fields are prefixed by _
        private int _age;

        // constructors -- homework
        public Person()
        {
            Console.WriteLine("Person() called.");    
        }

        public int Age
        {
            get { return _age; }
            set {
                if (value < 0)
                    throw new Exception($"Invalid Age: {value}");
                _age = value; 
            }
        }

        // auto-implemented property = field + basic getter/setter (no validation)
        //  field is created internally
        //  also minimal getter/setter created internally
        public string Name
        {
            get;
            set;
        }
        public void Display()
        {
            Console.WriteLine($"Person: Name={this.Name}, Age={this.Age}");
        }
    }
    /*
    Enums -- Readable constants
        By default, enums are stored as "int" internally.
        You may change underlying storage using inheritance.
            enum MyEnum : short { Const1, Const2, Const3 }
    */
    enum Weekday
    {
        Monday, 
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    /*
    Multiple enum constants may have same value, However this is not readable
    and may produce unexpected results.
    */
    enum Color
    {
        Red = 4,    // 4
        Green,      // 5
        Blue = 2,   // 2
        Yellow,     // 3
        Black,      // 4
        White = -3, // -3
        Purple      // -2
    }

    enum Menu
    {
        Exit, Add, Subtract, Multiply, Divide
    }
    internal class Program
    {
        static void Main1(string[] args)
        {
            #region Struct and Properties
            // local variables must be assigned before use -- compiler error
            Point p1 = new Point(); // "local" "value types" are allocated on stack
            Console.WriteLine($"p1: ({p1.GetX()}, {p1.GetY()})");

            Point p2 = new Point(2, 3);
            Console.WriteLine($"p2: ({p2.X}, {p2.Y})");

            Point p3 = new Point();
            p3.X = 5;
            p3.Y = 8;
            Console.WriteLine($"p3: ({p3.X}, {p3.Y})");
            #endregion
        }
        static void Main2(string[] args)
        {
            #region Class and Properties
            Person pr1 = new Person();
            //pr1.Age = -5;     // System.Exception: Invalid Age: -5
            pr1.Age = 5;        // okay -- classic property
            pr1.Name = "John";  // okay -- auto-implemented property
            pr1.Display();
            #endregion

            #region Object Initializer
            // Object can be initialized while allocating it - using properties.
            Person pr2 = new Person() { Name = "James Bond", Age = 65 };
            pr2.Display();

            Person pr3 = new Person() { Name = "Superman" };
            pr3.Display();
            #endregion

            #region Collection Initializers
            // Collections can also be iniailized while creating objects
            List<string> list1 = new List<string>() { "Mango", "Lemon", "Apple" };
            foreach (string s in list1)
                Console.WriteLine(s);
            #endregion
        }
        static void Main(string[] args)
        {
            Weekday d1 = new Weekday(); // default is zero
            Console.WriteLine("d1 = " + d1);

            Weekday d2 = Weekday.Wednesday;
            Console.WriteLine("d2 = " + d2 + " -- ordinal = " + (int)d2);

            Weekday d3 = (Weekday)6;
            Console.WriteLine("d3 = " + d3 + " -- ordinal = " + (int)d3);

            Weekday d4 = (Weekday)10;
            Console.WriteLine("d4 = " + d4 + " -- ordinal = " + (int)d4);

            Color c1 = new Color();     // default is zero
            Console.WriteLine("c1 = " + c1);

            Color c2 = Color.Black;
            Console.WriteLine("c2 = " + c2 + " -- ordinal = " + (int)c2);

            Color c3 = Color.Purple;
            Console.WriteLine("c3 = " + c3 + " -- ordinal = " + (int)c3);
            
            Array menus = Enum.GetValues(typeof(Menu));
            foreach (Menu m in menus)
                Console.WriteLine((int)m + ". " + m);
            Console.Write("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            Menu option = (Menu)choice;
            Console.WriteLine("Your choice: " + option);
        }
    }
}
