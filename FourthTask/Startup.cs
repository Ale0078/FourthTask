using System;
using System.IO;
using NLog;

using static System.Console;

using FourthTask.Messages;
using FourthTask.Controllers;
using FourthTask.Logic.Components.Builders;
using FourthTask.Logic.UserInterface.Abstracts;
using LibToTasks.Validation.Interfaces;
using LibToTasks.Builders;

namespace FourthTask
{
    public class Startup
    {
        private readonly ILogger _logger;
        private readonly string[] _mainArguments;
        private readonly string _filePath;

        private readonly IValidator _checker;

        public Startup(string[] mainArguments) 
        {
            _logger = LogManager.GetCurrentClassLogger();
            _checker = new DefaultValidatorBuilder().Create();

            _mainArguments = mainArguments;

            if (_mainArguments.Length > 0)
            {
                _filePath = Path.Combine(Environment.CurrentDirectory, _mainArguments[0]);
            }
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

            using FileStream reader = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
            using FileStream writer = new FileStream($"{_filePath}_Replaced.txt", FileMode.Create, FileAccess.Write);

            Controller parserController = GetController(reader, writer);

            WriteLine($"Word \"{_mainArguments[1]}\" was found {parserController.CountString(_mainArguments[1])} times");
        }

        private void SecondMode() 
        {
            if (!_checker.CheckValue(fileName => File.Exists(fileName), _filePath, false))
            {
                WriteLine(UserMessage.FILE_ERROR);

                return;
            }

            using FileStream reader = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
            using FileStream writer = new FileStream($"{_filePath}_Replaced.txt", FileMode.Create, FileAccess.Write);

            Controller parserController = GetController(reader, writer);

            parserController.ReplaceString(_mainArguments[1], _mainArguments[2]);
        }

        private Controller GetController(Stream reader, Stream writer) 
        {
            try
            {
                return new ParserController(
                counterBuilder: new TextConterBuidler(
                    streamToCountString: reader),
                replacerBuilder: new TextReplacerBuilder(
                    streamToGetValueToReplace: reader,
                    streamToSetReplacingValue: writer));
            }
            finally 
            {
                _logger.Info(LogMessage.GET_CONTROLLER);
            }
        }
    }
}
