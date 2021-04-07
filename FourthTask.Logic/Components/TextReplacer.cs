using System;
using System.Text;
using System.IO;
using System.Diagnostics;

using FourthTask.Logic.Components.Interfaces;

namespace FourthTask.Logic.Components
{
    public class TextReplacer : ITextReplacer, IDisposable
    {
        private readonly Stream _streamToGetValueToReplace;
        private readonly Stream _streamToSetReplacingValue;

        public TextReplacer(Stream streamToGetValueToReplace, Stream streamToSetReplacingValue) 
        {
            _streamToGetValueToReplace = streamToGetValueToReplace;
            _streamToSetReplacingValue = streamToSetReplacingValue;
        }

        public void ReplaceString(string oldString, string newString)//ToDo: Delete Stopwatch
        {
            Stopwatch timer = new();

            timer.Start();

            int count = 1000;
            byte[] buffer = new byte[count];

            while (_streamToGetValueToReplace.Read(buffer, 0, count) != 0) 
            {
                string lineToReplace = Encoding.UTF8
                    .GetString(buffer)
                    .Replace(oldString, newString);

                byte[] bufferToSetReplacingValue = Encoding.UTF8.GetBytes(lineToReplace);

                _streamToSetReplacingValue.Write(bufferToSetReplacingValue, 0, bufferToSetReplacingValue.Length);
            }

            timer.Stop();

            Console.WriteLine($"ReplaceString: time {timer.ElapsedMilliseconds} ms");
        }

        public void Dispose() 
        {
            _streamToGetValueToReplace.Dispose();
            _streamToSetReplacingValue.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
