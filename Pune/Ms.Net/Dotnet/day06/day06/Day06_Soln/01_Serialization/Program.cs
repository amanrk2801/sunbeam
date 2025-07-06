using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace _01_Serialization
{
    public class Book
    {
        [JsonPropertyName("srno")]
        public int? Id { get; set; }
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        [JsonPropertyName("author")]
        public string? Author { get; set; }
        [JsonPropertyName("category")]
        public string? Category { get; set; }
        [JsonPropertyName("price")]
        public double? Price { get; set; }
        [JsonIgnore]
        public double? Tax { 
            get { return Price * 0.05; } 
        }
        public override string ToString()
        {
            return $"Book: Id={Id}, Title={Title}, Author={Author}, Category={Category}, Price={Price}";
        }
    }

    internal class Program
    {
        static void Main1(string[] args)
        {
            string path = "file1.xml";
            XmlSerializer xs = new XmlSerializer(typeof(Book));

            #region serialize book in xml format
            Book b1 = new Book() { Id = 1, Title = "Atlas Shrugged", Author = "Ayn Rand", Category = "Novel", Price = 734.54 };
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                xs.Serialize(fs, b1);
                Console.WriteLine("File Saved.");
            }
            #endregion

            #region deserialize book from xml format
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                Book b2 = (Book)xs.Deserialize(fs);
                Console.WriteLine("File Read: " + b2);
            }
            #endregion
        }

        static void Main2(string[] args)
        {
            string path = "file2.json";

            #region serialize book in json format
            Book b1 = new Book() { Id = 1, Title = "Atlas Shrugged", Author = "Ayn Rand", Category = "Novel", Price = 734.54 };
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                JsonSerializer.Serialize(fs, b1);
                Console.WriteLine("File Saved.");
            }
            #endregion

            #region deserialize book from xml format
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                Book? b2 = JsonSerializer.Deserialize<Book>(fs);
                Console.WriteLine("File Read: " + b2);
                Console.WriteLine("Book Title: "  + b2?.Title);
            }
            #endregion
        }

        static void Main3(string[] args)
        {
            string path = "file3.json";

            #region serialize book in json format
            Book[] arr1 = {
                new Book() { Id = 1, Title = "Atlas Shrugged", Author = "Ayn Rand", Category = "Novel", Price = 734.54 },
                new Book() { Id = 2, Title = "The Alchemist", Author = "Paulo Cohelo", Category = "Novel", Price = 564.56 },
            };
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                JsonSerializer.Serialize(fs, arr1);
                Console.WriteLine("File Saved.");
            }
            #endregion

            #region deserialize book from json format
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                Book[]? arr2 = JsonSerializer.Deserialize<Book[]>(fs);
                Console.WriteLine("File Read as Array: " + arr2?.Length);
                foreach(Book b in arr2)
                    Console.WriteLine(b);
            }
            #endregion

            #region deserialize book from json format
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                List<Book>? list = JsonSerializer.Deserialize<List<Book>>(fs);
                Console.WriteLine("File Read as List: " + list?.Count);
                foreach (Book b in list)
                    Console.WriteLine(b);
            }
            #endregion
        }

        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            try
            {
                string url = @"https://raw.githubusercontent.com/nilesh-g/learn-web/refs/heads/main/data/novels.json";

                HttpResponseMessage? resp = client.GetAsync(url).Result;
                Console.WriteLine(resp + "\n");

                string? content = resp.Content.ReadAsStringAsync().Result;
                Console.WriteLine(content + "\n");

                List<Book>? books = JsonSerializer.Deserialize<List<Book>>(content);
                Console.WriteLine("Books Read: " + books?.Count);
                foreach (Book b in books)
                    Console.WriteLine(b);

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Message: " + ex.Message);
                //Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                client.Dispose();
                Console.WriteLine("\nBye!!");
            }
        }
    }
}
