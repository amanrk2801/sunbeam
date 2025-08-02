namespace _01_Struct
{
    struct Point
    {
        private int x; 
        private int y;
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
        public int Z
        {
            get; set;
        }
        public Point()
        {
            x = 1; y = 1;
        }
        public Point(int x, int y)
        {
            this.x = x; this.y = y;
        }

        // ERROR: Only class types can contain destructors
        //~Point()
        //{
        //    Console.WriteLine("Destroy Point...");
        //}
        public void Display()
        {
            Console.WriteLine($"({x},{y})");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point();
            p1.Display();
            Point p2 = new Point(2, 4);
            p2.Display();
            Console.WriteLine($"X = {p2.X}, Y = {p2.Y}, Z = {p2.Z}");
        }
    }
}
