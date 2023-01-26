namespace EduHome.Business.Exceptions;

public sealed class IncorrectFileFormatException:Exception
{
    public IncorrectFileFormatException(string message):base(message)
    {
    }
}
