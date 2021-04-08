namespace FourthTask.Messages
{
    public class LogMessage
    {
        public const string SET_COUNTER_BUILDER = "New Counter Builder was setted up";
        public const string SET_REPLACER_BUILDER = "New Replacer Builder was setted up";
        public const string COUNT_STRING = "Method CountString was started in ParserController";
        public const string REPLACE_STRING = "Method ReplaceString was started in ParserController";

        public const string STARTUP = "Program completed";
        public const string STARTUP_ERROR = "Invalid amount  of arguments.\n" +
                        "If you want to count string in file you has to use first mode:\n" +
                        "[filename] [string] where filename - file in current repository.\n" +
                        "If you want to get new file with replacing stirng that you need you has to use second mode:\n" +
                        "[filename] [oldstring] [newstring] where filename - file in current repository.";
        public const string GET_CONTROLLER = "Controller was created";
    }
}
