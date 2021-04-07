using FourthTask.Logic.Components.Builders.Interfaces;

namespace FourthTask.Logic.UserInterface.Abstracts
{
    public abstract class Controller
    {
        protected ITextCounterBuilder CounterBuilder { get; set; }
        protected ITextReplacerBuilder ReplacerBuilder { get; set; } 

        public Controller(ITextCounterBuilder counterBuilder, ITextReplacerBuilder replacerBuilder)
        {
            CounterBuilder = counterBuilder;
            ReplacerBuilder = replacerBuilder;
        }

        public virtual void SetCounterBuilder(ITextCounterBuilder counterBuilder) 
        {
            CounterBuilder = counterBuilder;
        }

        public virtual void SetReplacerBuilder(ITextReplacerBuilder replacerBuilder) 
        {
            ReplacerBuilder = replacerBuilder;
        }

        public abstract void ReplaceString(string oldStirng, string newString);
        public abstract int CountString(string stringToCount);
    }
}
