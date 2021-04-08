namespace FourthTask.Messages
{
    public class UserMessage
    {
        public const string FILE_ERROR = "You has to enter a filename that located in current repository";
        public const string STARTUP_ERROR = "If you want to count string in file you has to use first mode:\n" +
                        "[filename] [string] where filename - file in current repository.\n" +
                        "If you want to get new file with replacing stirng that you need you has to use second mode:\n" +
                        "[filename] [oldstring] [newstring] where filename - file in current repository.";
    }
}
