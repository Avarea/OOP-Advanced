namespace P01.Logger.Models.Contracts
{
    public interface ILayout
    {
        string FormatError(IError error);
    }
}
