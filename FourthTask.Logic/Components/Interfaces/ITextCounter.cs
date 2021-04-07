using System;

namespace FourthTask.Logic.Components.Interfaces
{
    public interface ITextCounter : IDisposable
    {
        int CountString(string stringToCount);
    }
}
