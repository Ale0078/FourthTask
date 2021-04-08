using NLog;

using FourthTask.Messages;
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

            _logger.Info(LogMessage.SET_COUNTER_BUILDER);
        }

        public override void SetReplacerBuilder(ITextReplacerBuilder replacerBuilder)
        {
            base.SetReplacerBuilder(replacerBuilder);

            _logger.Info(LogMessage.SET_REPLACER_BUILDER);
        }

        public override int CountString(string stringToCount)
        {
            _logger.Info(LogMessage.COUNT_STRING);

            using ITextCounter counter = CounterBuilder.Create();

            return counter.CountString(stringToCount);
        }

        public override void ReplaceString(string oldStirng, string newString)
        {
            _logger.Info(LogMessage.REPLACE_STRING);

            using ITextReplacer replacer = ReplacerBuilder.Create();

            replacer.ReplaceString(oldStirng, newString);
        }
    }
}
