public class LoggingBroker
{
    public void LogInfo(string message)
    {
        Console.WriteLine($"INFO: {message}");
    }

    public void LogError(string errorMessage)
    {
        Console.WriteLine($"ERROR: {errorMessage}");
    }
    public void LogException(Exception exception)
    {
        Console.WriteLine($"EXCEPTION: {exception.Message}");
    }
}
