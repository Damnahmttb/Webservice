using Serilog;

namespace LoggingService.Loggers
{
    public interface IEmailLogger
    {
        public bool LogEmail(string message);

    }
    public class EmailLogger : IEmailLogger
    {
        private readonly ILogger logger;

        public EmailLogger()
        {
            logger=new LoggerConfiguration().MinimumLevel.Information().WriteTo.Console().CreateLogger();
        }

        public bool LogEmail(string message)
        {
            //Email yollma islemi yapilmasi lazim onun yerine goruntu olsun diye bunu ekleidm
            logger.Information($"Email Log - This Exception is type of : {message}");
            return true;
        }
    }

}
