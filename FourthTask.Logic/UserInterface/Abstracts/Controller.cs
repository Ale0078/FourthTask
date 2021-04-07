using FourthTask.Logic.Components.Builders.Interfaces;

namespace FourthTask.Logic.UserInterface.Abstracts
{
    public abstract class Controller
    {
        protected ITextCounterBuilder CounterBuilder { get; set; }
        protected ITextReplacerBuilder ReplacerBuilder { get; set; } 
        protected Model CouterAndReplacerContainer { get; set; }

        public Controller(Model counterAndReplacerContainer, ITextCounterBuilder counterBuilder,
            ITextReplacerBuilder replacerBuilder)
        {
            CounterBuilder = counterBuilder;
            ReplacerBuilder = replacerBuilder;
            CouterAndReplacerContainer = counterAndReplacerContainer;
        }

        public virtual void SetCounterBuilder(ITextCounterBuilder counterBuilder) 
        {
            CounterBuilder = counterBuilder;
        }

        public virtual void SetReplacerBuilder(ITextReplacerBuilder replacerBuilder) 
        {
            ReplacerBuilder = replacerBuilder;
        }

        public virtual void SetTextCounerToModel()
        {
            CouterAndReplacerContainer.SetTextCounter(CounterBuilder.Create());
        }

        public virtual void SetTextReplacerToModel() 
        {
            CouterAndReplacerContainer.SetTextReplacer(ReplacerBuilder.Create());
        }

        public abstract void ReplaceString(string oldStirng, string newString);
        public abstract int CountString(string stringToCount);
    }
}
