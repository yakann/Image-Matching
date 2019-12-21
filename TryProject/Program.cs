using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            DirectoryInfo d = new DirectoryInfo(@"C:\Users\mahmu\source\repos\ConsoleApp1\ConsoleApp1\");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.txt"); //Getting Text files
            string str = "";
            foreach (FileInfo file in Files)
            {
                str = str + ", " + file.Name;
                Console.WriteLine(str);
            }

            //string[] filePaths = Directory.GetFiles(@"C:\Users\mahmu\source\repos\ConsoleApp1\ConsoleApp1", "*.txt",
            //    SearchOption.TopDirectoryOnly);

            //foreach (var i in filePaths)
            //{
            //    Console.WriteLine(i);
            //}

            Console.ReadLine();
        }
    }
}