using System;
using System.IO;

using FourthTask.Logic.Components.Interfaces;
using FourthTask.Logic.Components.Builders.Interfaces;

namespace FourthTask.Logic.Components.Builders
{
    public class TextConterBuidler : ITextCounterBuilder
    {
        private bool disposed;

        private Stream StreamToCountString { get; set; }

        ~TextConterBuidler() 
        {
            DisposeWithoutGC();
        }

        public TextConterBuidler(Stream streamToCountString) 
        {
            StreamToCountString = streamToCountString;
        }

        public ITextCounter Create() 
        {
            return new TextCounter(StreamToCountString);
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
                StreamToCountString.Close();
            }

            disposed = true;
        }
    }
}
