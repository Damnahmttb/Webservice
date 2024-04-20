using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingService.Loggers
{
  public interface IEventLogger
{
        bool LogEvent(string message);
}

public class EventLogger : IEventLogger
{
        private readonly ILogger logger;
        public EventLogger()
        {
            logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }
        public bool LogEvent(string message)
        {   
            logger.Information(message);
            return true;
        }
}


}
