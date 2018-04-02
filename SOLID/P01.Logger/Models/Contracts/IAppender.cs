using P01.Logger.Models.Enums;

namespace P01.Logger.Models.Contracts
{
    public interface IAppender : ILevelable
    {
        ILayout Layout { get; }

        void Append(IError error);
    }
}
