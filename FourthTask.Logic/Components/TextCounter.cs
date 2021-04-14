using System;
using System.IO;
using System.Text;
using System.Diagnostics;

using FourthTask.Logic.Components.Interfaces;

namespace FourthTask.Logic.Components
{
    public class TextCounter : ITextCounter
    {
        //private bool disposed;
        private readonly Stream _streamToGetString;
        private char[] _separators = new char[]
                { ' ', ',', '.', ';', ':', '!', '?', '|', '<', '>', '"', '\r', '\n', '\t', '(', ')', '\0' };

        public TextCounter(Stream streamToGetString)
        {
            _streamToGetString = streamToGetString;
        }

        //~TextCounter() 
        //{
        //    Dispose(false);
        //}

        public int CountString(string stringToCount) //ToDo: Delete Stopwatch
        {
            int stringCounter = 0;

            Stopwatch timer = new();

            timer.Start();

            int count = 1000;
            int offset = 0;
            byte[] buffer = new byte[count];            

            while (_streamToGetString.Read(buffer, offset, count - offset) != 0) 
            {
                string line = Encoding.UTF8.GetString(buffer);

                buffer = new byte[count];

                string[] possibleAnswers = line.Split(_separators);

                string possibleStringToCount = possibleAnswers[^1];

                if (possibleStringToCount.Length <= stringToCount.Length)
                {
                    SetAllParametrsToStream(
                        offset: ref offset,
                        stringToCount: ref stringToCount,
                        possibleStringToCount: ref possibleStringToCount,
                        buffer: ref buffer);
                }

                foreach (var item in possibleAnswers)
                {
                    if (item.Equals(stringToCount))
                    {
                        stringCounter++;
                    }
                }                
            }

            timer.Stop();

            Console.WriteLine($"CountString: {timer.ElapsedMilliseconds} ms");

            return stringCounter;
        }

        private void SetAllParametrsToStream(ref int offset, ref string stringToCount, ref string possibleStringToCount,
            ref byte[] buffer)
        {
            int counter = 0;

            for (int i = 0; i < possibleStringToCount.Length; i++)
            {
                if (stringToCount[i] == possibleStringToCount[i])
                {
                    counter++;
                }
            }

            if (counter == possibleStringToCount.Length)
            {
                offset = counter;

                var amountOfBytes = Encoding.UTF8.GetBytes(possibleStringToCount);

                for (int i = 0; i < amountOfBytes.Length; i++)
                {
                    buffer[i] = amountOfBytes[i];
                }
            }
            else
            {
                offset = 0;
            }
        }

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //private void Dispose(bool disposing) 
        //{
        //    if (!disposed) 
        //    {
        //        if (disposing) 
        //        {
        //            Array.Clear(_separators, 0, _separators.Length);
        //        }

        //        _streamToGetString.Close();
        //    }

        //    disposed = true;
        //}
    }
}