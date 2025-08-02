using System.Dynamic;
using System.Text.Json;

namespace _07_Dynamic
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            dynamic num = 102;
            dynamic str = "Hello, DAC!";
            Console.WriteLine("Num : " + num);
            Console.WriteLine("Str : " + str);

            dynamic obj = new
            {
                Name = "Nilesh",
                Age = 42
            };
            Console.WriteLine("Obj : " + obj);
            Console.WriteLine("Obj Name : " + obj.Name);
            Console.WriteLine("Obj Age : " + obj.age);
            // RuntimeBinder.RuntimeBinderException - if method name/prop name is wrong
        }

        static void Main2(string[] args)
        {
            dynamic obj = new ExpandoObject(); // dynamic dict
            obj.Name = "James Bond";
            obj.Age = 65;
            obj.Addr = "London";
            Console.WriteLine("obj = " + obj); // System.Dynamic.ExpandoObject
            Console.WriteLine("obj Type = " + obj.GetType()); // System.Dynamic.ExpandoObject
            Console.WriteLine("obj Name = " + obj.Name.ToUpper());
        }

        static void Main(string[] args)
        {

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = @"https://raw.githubusercontent.com/nilesh-g/learn-web/refs/heads/main/data/novels.json";

                    HttpResponseMessage? resp = client.GetAsync(url).Result;
                    Console.WriteLine(resp + "\n");

                    string? content = resp.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(content + "\n");

                    dynamic[]? books = JsonSerializer.Deserialize<ExpandoObject[]>(content);
                    foreach (dynamic b in books)
                        Console.WriteLine($"Book: [{b.srno}, {b.title}, {b.price}]");
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Message: " + ex.Message);
                //Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
