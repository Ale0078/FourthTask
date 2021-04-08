using System;
using System.Text;
using System.IO;
using System.Diagnostics;

using FourthTask.Logic.Components.Interfaces;

namespace FourthTask.Logic.Components
{
    public class TextReplacer : ITextReplacer
    {
        private bool disposed;
        private readonly Stream _streamToGetValueToReplace;
        private readonly Stream _streamToSetReplacingValue;
        private char[] _separators = new char[]
                { ' ', ',', '.', ';', ':', '!', '?', '|', '<', '>', '"', '\r', '\n', '\t', '(', ')', '\0' };        

        public TextReplacer(Stream streamToGetValueToReplace, Stream streamToSetReplacingValue) 
        {
            _streamToGetValueToReplace = streamToGetValueToReplace;
            _streamToSetReplacingValue = streamToSetReplacingValue;
        }

        public void ReplaceString(string oldString, string newString)//ToDo: Delete Stopwatch
        {
            Stopwatch timer = new();

            timer.Start();

            int offset = 0;
            int count = 1000;
            byte[] buffer = new byte[count];

            while (_streamToGetValueToReplace.Read(buffer, offset, count - offset) != 0) 
            {
                string lineToReplace = Encoding.UTF8
                    .GetString(buffer)
                    .Replace(oldString, newString);

                buffer = new byte[1000];
                
                byte[] bufferToSetReplacingValue = Encoding.UTF8.GetBytes(lineToReplace);

                string possibleOldString = lineToReplace.Split(_separators)[^1];

                if (possibleOldString.Length <= oldString.Length)
                {                    
                    int counter = 0;

                    for (int i = 0; i < possibleOldString.Length; i++)
                    {
                        if (oldString[i] == possibleOldString[i])
                        {
                            counter++;
                        }
                    }

                    if (counter == possibleOldString.Length)
                    {
                        offset = counter;

                        var amountOfBytes = Encoding.UTF8.GetBytes(possibleOldString);

                        for (int i = 0; i < amountOfBytes.Length; i++)
                        {
                            buffer[i] = amountOfBytes[i];
                            bufferToSetReplacingValue[^(i + 1)] = 0;
                        }
                    }
                    else
                    {
                        offset = 0;
                    }
                }
                
                _streamToSetReplacingValue.Write(bufferToSetReplacingValue, 0, bufferToSetReplacingValue.Length);
            }

            timer.Stop();

            Console.WriteLine($"ReplaceString: time {timer.ElapsedMilliseconds} ms");
        }

        public void Dispose() 
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing) 
        {
            if (!disposed) 
            {
                if (disposing) 
                {
                    _separators = null;
                }

                _streamToGetValueToReplace.Close();
                _streamToSetReplacingValue.Close();
            }

            disposed = true;
        }
    }
}
