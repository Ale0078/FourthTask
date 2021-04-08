using NLog;

using FourthTask.Logic.Components.Interfaces;
using FourthTask.Logic.UserInterface.Abstracts;
using FourthTask.Logic.Components.Builders.Interfaces;

namespace FourthTask.Controllers
{
    public class ParserController : Controller
    {
        private readonly ILogger _logger;

        public ParserController(ITextCounterBuilder counterBuilder, ITextReplacerBuilder replacerBuilder) :
            base(counterBuilder, replacerBuilder)
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public override void SetCounterBuilder(ITextCounterBuilder counterBuilder)
        {
            base.SetCounterBuilder(counterBuilder);

            _logger.Info("New Counter Builder was setted up");
        }

        public override void SetReplacerBuilder(ITextReplacerBuilder replacerBuilder)
        {
            base.SetReplacerBuilder(replacerBuilder);

            _logger.Info("New Replacer Builder was setted up");
        }

        public override int CountString(string stringToCount)
        {
            _logger.Info("Method CountString was started in ParserController");

            using ITextCounter counter = CounterBuilder.Create();

            return counter.CountString(stringToCount);
        }

        public override void ReplaceString(string oldStirng, string newString)
        {
            _logger.Info("Method ReplaceString was started in ParserController");

            using ITextReplacer replacer = ReplacerBuilder.Create();

            replacer.ReplaceString(oldStirng, newString);
        }
    }
}
