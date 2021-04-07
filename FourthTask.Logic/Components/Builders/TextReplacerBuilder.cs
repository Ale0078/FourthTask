using System;
using System.IO;

using FourthTask.Logic.Components.Interfaces;
using FourthTask.Logic.Components.Builders.Interfaces;

namespace FourthTask.Logic.Components.Builders
{
    public class TextReplacerBuilder : ITextReplacerBuilder
    {
        private bool disposed;

        private Stream StreamToGetValueToReplace { get; set; }
        private Stream StreamToSetReplacingValue { get; set; }

        public TextReplacerBuilder(Stream streamToGetValueToReplace, Stream streamToSetReplacingValue) 
        {
            StreamToGetValueToReplace = streamToGetValueToReplace;
            StreamToSetReplacingValue = streamToSetReplacingValue;
        }

        ~TextReplacerBuilder() 
        {
            DisposeWithoutGC();
        }

        public ITextReplacer Create() 
        {
            return new TextReplacer(StreamToGetValueToReplace, StreamToSetReplacingValue);
        }

        public void Dispose() 
        {
            DisposeWithoutGC();
            GC.SuppressFinalize(this);
        }

        private void DisposeWithoutGC() 
        {
            if (!disposed)
            {
                StreamToGetValueToReplace.Close();
                StreamToSetReplacingValue.Close();
            }

            disposed = true;
        }
    }
}
