namespace EduHome.Business.Exceptions;

public sealed class IncorrectFileSizeException:Exception
{
    public IncorrectFileSizeException(string message):base(message)
    {
    }
}
