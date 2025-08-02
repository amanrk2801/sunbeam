namespace _03_GcResourceManagement
{
    class MyResource : IDisposable
    {
        // file
        public MyResource()
        {
            // open file
            Console.WriteLine("MyResource obj created.");
        }
        public void UseResource()
        {
            // file write/read
            Console.WriteLine("Using MyResource");
        }
        public void Dispose()
        {
            // close file
            Console.WriteLine("MyResource obj disposed.");
        }
        ~MyResource()
        {
            // close file
            Console.WriteLine("MyResource obj will be destroyed.");
        }
    }
    internal class Program
    {
        static void Main1(string[] args)
        {
            MyResource obj1 = new MyResource();
            obj1 = null;
            GC.Collect(); // mark unused objs for garbage collection
                // the Finalize() is always called in next pass.
            GC.WaitForPendingFinalizers();
                // wait for Finalize() being called for marked objects
            Console.WriteLine("Bye!!");
        }
        static void Main2(string[] args)
        {
            MyResource obj = null;
            try
            {
                obj = new MyResource();
                obj.UseResource();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
               obj.Dispose();
            }
        }
        static void Main(string[] args)
        {
            try
            {
                using (MyResource obj = new MyResource())
                {
                    obj.UseResource();
                } // obj.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
