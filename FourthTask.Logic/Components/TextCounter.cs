using System;
using System.IO;
using System.Text;
using System.Diagnostics;

using FourthTask.Logic.Components.Interfaces;

namespace FourthTask.Logic.Components
{
    public class TextCounter : ITextCounter, IDisposable
    {
        private readonly char[] _separators = new char[]
                { ' ', ',', '.', ';', ':', '!', '?', '|', '<', '>', '"', '\r', '\n', '\t', '(', ')' };

        private readonly Stream _streamToGetString;

        public TextCounter(Stream streamToGetString)
        {
            _streamToGetString = streamToGetString;
        }

        public int CountString(string stringToCount) //ToDo: Delete Stopwatch
        {
            int stringCounter = 0;

            Stopwatch timer = new();

            timer.Start();

            int count = 1000;
            byte[] buffer = new byte[count];            

            while (_streamToGetString.Read(buffer, 0, count) != 0) 
            {
                string line = Encoding.UTF8.GetString(buffer);

                string[] possibleAnswers = line.Split(_separators);

                foreach (var item in possibleAnswers)
                {
                    if (item.Equals(stringToCount))
                    {
                        stringCounter++;
                    }
                }

                buffer = new byte[count];
            }

            timer.Stop();

            Console.WriteLine($"CountString: {timer.ElapsedMilliseconds} ms");

            return stringCounter;
        }

        public void Dispose()
        {
            _streamToGetString.Dispose();
        }
    }
}