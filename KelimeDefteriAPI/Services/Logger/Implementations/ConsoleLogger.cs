namespace KelimeDefteriAPI.Services.Logger.Implementations
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
