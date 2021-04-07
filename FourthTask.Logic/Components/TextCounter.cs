using System;
using System.IO;
using System.Diagnostics;

using FourthTask.Logic.Components.Interfaces;

namespace FourthTask.Logic.Components
{
    public class TextCounter : ITextCounter
    {
        private string _filePathToGetString;

        public TextCounter(string fileNameToGetString)
        {
            _filePathToGetString = Path.Combine(Environment.CurrentDirectory, fileNameToGetString);
        }

        public int CountString(string stringToCount) //ToDo: Delete Stopwatch
        {
            int stringCounter = 0;

            Stopwatch timer = new();

            timer.Start();

            foreach (var item in File.ReadLines(_filePathToGetString)) 
            {
                string[] possibleAnswers = item.Split();

                for (int i = 0; i < possibleAnswers.Length; i++)
                {
                    if (possibleAnswers[i].Equals(stringToCount)) 
                    {
                        stringCounter++;
                    }
                }
            }

            timer.Stop();

            Console.WriteLine($"CountString: {timer.ElapsedMilliseconds} ms");

            return stringCounter;
        }
    }
}