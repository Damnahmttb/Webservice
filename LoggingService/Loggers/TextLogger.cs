using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingService.Loggers
{
    public interface ITextFileLogger
    {
        bool Log(string message);
    }

    public class TextFileLogger : ITextFileLogger
    {
        private readonly ILogger logger;
        public TextFileLogger()
        {
            logger = new LoggerConfiguration().WriteTo.File("logs/TextFilelogger/mylogs").CreateLogger();
        }

        public bool Log(string message)
        {
            logger.Information(message);
            return true;
        }
    }

}
