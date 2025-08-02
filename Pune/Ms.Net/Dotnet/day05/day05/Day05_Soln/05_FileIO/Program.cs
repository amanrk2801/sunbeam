using System.Runtime.Serialization.Formatters.Binary;

namespace _05_FileIO
{
    internal class Program
    {
        // File write and read operation
        static void Main1(string[] args)
        {
            string path = "file1.txt";
            Console.WriteLine("enter some text to write into the file: ");
            string line = Console.ReadLine();
            //File.WriteAllText(path, line);
            File.AppendAllText(path, line);

            string text = File.ReadAllText(path);
            Console.WriteLine("reading the file: ");
            Console.WriteLine(text);
        }

        static void Main2(string[] args)
        {
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("Drives: " + string.Join(", ", drives));

            //string dirpath = @"D:\Nilesh\Feb25\DAC\dotnet";
            Console.Write("Enter Dir Path: ");
            string dirpath = Console.ReadLine();
            IEnumerable<string> files = Directory.EnumerateFileSystemEntries(dirpath);
            foreach (string file in files)
                Console.WriteLine(file);
        }

        static void Main3(string[] args)
        {
            // Text File Writing
            string path = "file2.txt";
            // step 1 - create FileStream object -- for file write
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            // step 2 - create StreamWriter object for that file stream
            StreamWriter wr = new StreamWriter(fs);
            // step 3 - write the data
            wr.WriteLine("Hello, DAC!!");
            wr.WriteLine("Are you there??");
            int num = 99999999;
            wr.Write(num);
            // step 4 - close stream writer
            wr.Close();
            // step 5 - close file stream
            fs.Close();
            Console.WriteLine("File Saved.");
        }
        static void Main4(string[] args)
        {
            // Text File Reading
            string path = "file2.txt";
            // step 1 - create FileStream object -- for file read
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            // step 2 - create StreamReader object for that file stream
            StreamReader rd = new StreamReader(fs);
            // step 3 - read the data
            //string text = rd.ReadToEnd();
            //Console.WriteLine(text);
            string line = "";
            while (true)
            {
                line = rd.ReadLine();
                if (line == null) break;
                Console.WriteLine(line);
            }
            // step 4 - close stream reader
            rd.Close();
            // step 5 - close file stream
            fs.Close();
        }
        static void Main(string[] args)
        {
            string path = "file3.bin";
            Dept d1 = new Dept { DeptId = 10, Dname = "Accounting", Location = "New York" };

            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                bf.Serialize(fs, d1);
                Console.WriteLine("Dept File Saved.");
            } // fs closed

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                Dept d2 = (Dept)bf.Deserialize(fs);
                Console.WriteLine("Dept Read: " + d2);
            } // fs closed
        }
    }

    [Serializable]
    public class Dept
    {
        public int DeptId;
        public string Dname;
        [NonSerialized] // can be used only on fields (not on properties)
        public string Location;
        public override string ToString()
        {
            return $"Dept: Name={Dname}, Id={DeptId}, Loc={Location}";
        }
    }
}
