using System;
using System.IO;
using System.Diagnostics;

using FourthTask.Logic.Components.Interfaces;

namespace FourthTask.Logic.Components
{
    public class TextReplacer : ITextReplacer
    {
        private string _filePathToReplace;

        public TextReplacer(string fileNameToReplace) 
        {
            _filePathToReplace = Path.Combine(Environment.CurrentDirectory, fileNameToReplace);
        }

        public void ReplaceString(string oldString, string newString) //ToDo: Delete Stopwatch
        {
            Stopwatch timer = new();

            timer.Start();
            
            using FileStream newFileWithReplace = new($"Repleced_{_filePathToReplace}", FileMode.Create, FileAccess.Write);//ToDo: just Stream
            using StreamWriter writerToNewFile = new(newFileWithReplace);

            foreach (var item in File.ReadLines(_filePathToReplace))
            {
                writerToNewFile.WriteLine(item.Replace(oldString, newString));
            }

            timer.Stop();

            Console.WriteLine($"ReplaceString: time {timer.ElapsedMilliseconds} ms");
        }
    }
}
