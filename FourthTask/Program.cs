using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
namespace FourthTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new();

            stopwatch.Start();

            string filePath = Path.Combine(Environment.CurrentDirectory, "ERRORLOG.2");
            string replasingWard = "server";
            string toReplase = "2021-03-17";
             
            using FileStream stream = new($"{filePath}.txt", FileMode.OpenOrCreate, FileAccess.Write);
            using StreamWriter writer = new(stream); 

            foreach (string item in File.ReadLines(filePath)) 
            {
                writer.WriteLine(item.Replace(replasingWard, toReplase));
            }

            stopwatch.Stop();

            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            Console.ReadKey();
        }
    }
}
