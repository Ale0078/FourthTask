namespace FourthTask.Logic.Components.Interfaces
{
    public interface IParserStream : ICounterStream, IReplacerStream
    {
        ICounterStream Counter { get; protected set; }
        IReplacerStream Replacer { get; protected set; }
    }
}
