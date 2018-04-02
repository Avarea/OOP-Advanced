using System;
using P01.Logger.Models.Enums;

namespace P01.Logger.Models.Contracts
{
    public interface IError : ILevelable
    {
        DateTime DateTime { get; }

        string Message { get; }
    }
}
