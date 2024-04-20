namespace LoggingWebService.Loggers
{
    public interface IEmailLogger
    {
        public void LogEmail(string ExceptionType, string ExceptionSubject, string ExceptionBody);

    }
    public class EmailLogger : IEmailLogger
    {
        private readonly ILogger<EmailLogger> _logger;

        public EmailLogger(ILogger<EmailLogger> logger)
        {
            _logger = logger;
        }

        public void LogEmail(string ExceptionType, string ExceptionSubject, string ExceptionBody)
        {
            _logger.LogInformation($"Email Log - This Exception is type of : {ExceptionType}, Subject: {ExceptionSubject}, Body: {ExceptionBody}");
        }
    }
}
