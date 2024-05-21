namespace KalenderApp.Core;

public class InvalidValueException : Exception
{
    public InvalidValueException(string message) : base(message){}
}
