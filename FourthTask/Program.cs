using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using FourthTask.Logic.Components;

namespace FourthTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, "ERRORLOG.2");
            string newFilePath = Path.Combine(Environment.CurrentDirectory, "ERRORLOG.2.txt");

            using FileStream stream = new(filePath, FileMode.Open, FileAccess.Read);
            using FileStream stream1 = new(newFilePath, FileMode.Create, FileAccess.Write);
            using TextReplacer replacer = new(stream, stream1);

            replacer.ReplaceString("QWERT", " ");
            //Console.WriteLine(counter.CountString("QWERT"));
            //Stopwatch stopwatch = new();

            //stopwatch.Start();

            //string filePath = Path.Combine(Environment.CurrentDirectory, "ERRORLOG.2");
            //string replasingWard = "server";
            //string toReplase = "2021-03-17";
             
            //using FileStream stream = new($"{filePath}.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //using StreamWriter writer = new(stream); 

            //foreach (string item in File.ReadLines(filePath)) 
            //{
            //    writer.WriteLine(item.Replace(replasingWard, toReplase));
            //}

            //stopwatch.Stop();

            //Console.WriteLine(stopwatch.ElapsedMilliseconds);

            Console.ReadKey();
        }
    }
}
