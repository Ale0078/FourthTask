using System;
using System.IO;
using NLog;

using static System.Console;

using FourthTask.Messages;
using FourthTask.Controllers;
using FourthTask.Logic.Components.Builders;
using FourthTask.Logic.UserInterface.Abstracts;
using LibToTasks.Validation;

namespace FourthTask
{
    public class Startup
    {
        private readonly ILogger _logger;
        private readonly string[] _mainArguments;
        private readonly string _filePath;

        private readonly Validator _checker;

        public Startup(string[] mainArguments) 
        {
            _logger = LogManager.GetCurrentClassLogger();
            _checker = new Validator();

            _mainArguments = mainArguments;
            _filePath = Path.Combine(Environment.CurrentDirectory, _mainArguments[0]);
        }

        public void Start() 
        {
            switch (_mainArguments.Length) 
            {
                case 2:
                    FirstMode();
                    break;
                case 3:
                    SecondMode();
                    break;
                default:
                    _logger.Error(LogMessage.STARTUP_ERROR);

                    WriteLine(UserMessage.STARTUP_ERROR);
                    break;
            }

            _logger.Info(LogMessage.STARTUP);
        }

        private void FirstMode() 
        {
            if (!_checker.CheckValue(fileName => File.Exists(fileName), _filePath, false)) 
            {
                WriteLine(UserMessage.FILE_ERROR);

                return;
            }

            Controller parserController = GetController();

            WriteLine($"Word \"{_mainArguments[1]}\" was found {parserController.CountString(_mainArguments[1])} times");
        }

        private void SecondMode() 
        {
            if (!_checker.CheckValue(fileName => File.Exists(fileName), _filePath, false))
            {
                WriteLine(UserMessage.FILE_ERROR);

                return;
            }

            Controller parserController = GetController();

            parserController.ReplaceString(_mainArguments[1], _mainArguments[2]);
        }

        private Controller GetController() 
        {
            try
            {
                return new ParserController(
                counterBuilder: new TextConterBuidler(
                    streamToCountString: new FileStream(_filePath, FileMode.Open, FileAccess.Read)),
                replacerBuilder: new TextReplacerBuilder(
                    streamToGetValueToReplace: new FileStream(_filePath, FileMode.Open, FileAccess.Read),
                    streamToSetReplacingValue: new FileStream($"{_filePath}_Replaced.txt", FileMode.Create, FileAccess.Write)));
            }
            finally 
            {
                _logger.Info(LogMessage.GET_CONTROLLER);
            }
        }
    }
}
