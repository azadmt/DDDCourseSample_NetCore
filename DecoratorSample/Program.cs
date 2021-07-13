using System;
using System.Threading;

namespace DecoratorSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var simpleLogger = new SimpleLogger();
            ILogger decoratedLogger = new DateLoggerDecorator(new UserInfoLoggerDecorator(simpleLogger));

            decoratedLogger.Log("asdasdasdasd");
            Console.ReadKey();
        }
    }

    

    public interface ILogger
    {
        void Log(string msg);
    }


    public sealed class SimpleLogger : ILogger
    {
        public void Log(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    public class DateLoggerDecorator : ILogger
    {
        public DateLoggerDecorator(ILogger logger)
        {
            Logger = logger;
        }

        public ILogger Logger { get; }

        public void Log(string msg)
        {
            Console.WriteLine($"LogDate : {DateTime.Now.ToShortDateString()}");
            Logger.Log(msg);
        }
    }

    public class UserInfoLoggerDecorator : ILogger
    {
        public UserInfoLoggerDecorator(ILogger logger)
        {
            Logger = logger;
        }

        public ILogger Logger { get; }

        public void Log(string msg)
        {
            Console.WriteLine($"UserInfo : {Environment.UserName} ");

            Logger.Log(msg);
        }
    }
}
