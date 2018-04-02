using P01.Logger.Models.Enums;

namespace P01.Logger.Models.Contracts
{
    public interface ILevelable
    {
        ErrorLevel Level { get; }
    }
}
