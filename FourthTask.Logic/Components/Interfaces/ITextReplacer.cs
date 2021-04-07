using System;

namespace FourthTask.Logic.Components.Interfaces
{
    public interface ITextReplacer : IDisposable
    {
        void ReplaceString(string oldString, string newString);
    }
}
