using System;
using System.IO;

using FourthTask.Logic.Components.Interfaces;

namespace FourthTask.Logic.Components
{
    public class CounterStream : ICounterStream
    {
        private string _filePathToGetString;

        public CounterStream(string fileNameToGetString)
        {
            _filePathToGetString = Path.Combine(Environment.CurrentDirectory, fileNameToGetString);
        }

        public int CountString(string stringToCount) 
        {
            int stringCounter = 0;

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

            return stringCounter;
        }
    }
}