using System;
using System.IO;

using FourthTask.Logic.Components.Interfaces;
using FourthTask.Logic.Components.Builders.Interfaces;

namespace FourthTask.Logic.Components.Builders
{
    public class TextReplacerBuilder : ITextReplacerBuilder
    {
        private Stream StreamToGetValueToReplace { get; set; }
        private Stream StreamToSetReplacingValue { get; set; }

        public TextReplacerBuilder(Stream streamToGetValueToReplace, Stream streamToSetReplacingValue) 
        {
            StreamToGetValueToReplace = streamToGetValueToReplace;
            StreamToSetReplacingValue = streamToSetReplacingValue;
        }

        public ITextReplacer Create() 
        {
            return new TextReplacer(StreamToGetValueToReplace, StreamToSetReplacingValue);
        }
    }
}
