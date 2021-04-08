using System;

using FourthTask.Logic.Components.Interfaces;

namespace FourthTask.Logic.Components.Builders.Interfaces
{
    public interface ITextReplacerBuilder
    {
        ITextReplacer Create();
    }
}
