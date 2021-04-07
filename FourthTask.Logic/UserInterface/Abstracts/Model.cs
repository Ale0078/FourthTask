using System.IO;

using FourthTask.Logic.Components.Interfaces;

namespace FourthTask.Logic.UserInterface.Abstracts
{
    public abstract class Model
    {
        public ITextCounter Counter { get; protected set; }
        public ITextReplacer Replacer { get; protected set; }

        public abstract void SetTextCounter(ITextCounter counter);
        public abstract void SetTextReplacer(ITextReplacer replacer);
    }
}
