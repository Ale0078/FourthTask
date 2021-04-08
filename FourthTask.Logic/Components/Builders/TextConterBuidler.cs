using System;
using System.IO;

using FourthTask.Logic.Components.Interfaces;
using FourthTask.Logic.Components.Builders.Interfaces;

namespace FourthTask.Logic.Components.Builders
{
    public class TextConterBuidler : ITextCounterBuilder
    {
        private Stream StreamToCountString { get; set; }

        public TextConterBuidler(Stream streamToCountString) 
        {
            StreamToCountString = streamToCountString;
        }

        public ITextCounter Create() 
        {
            return new TextCounter(StreamToCountString);
        }
    }
}
