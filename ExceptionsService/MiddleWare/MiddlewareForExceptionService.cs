using ExceptionsService.Domain;
using LoggingService.Loggers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ExceptionsService.MiddleWare
{
    public class UserLevelMiddleware: IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
			}
			catch (UserLevelException err)
			{

                await context.Response.WriteAsync(err.Message);

            }
        }
    }
    public class CriticalUserMiddleware : IMiddleware
    {
        IEmailLogger emaillogger; ITextFileLogger filelogger; IEventLogger eventlogger;
        public CriticalUserMiddleware(IEmailLogger emaillogger, ITextFileLogger filelogger, IEventLogger eventlogger)
        {
            this.emaillogger = emaillogger;
            this.filelogger = filelogger;
            this.eventlogger = eventlogger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (CriticalUserException err)
            {

                if (!eventlogger.LogEvent(err.Message)) 
                {
                    if (!filelogger.Log(err.Message)
)
                    {
                        emaillogger.LogEmail(err.Message);

                    }
                }
            }
        }
    }
    public class CoreMiddleware : IMiddleware
    {
        IEmailLogger emaillogger; IDatabaseLogger database; ITextFileLogger filelogger; IEventLogger eventlogger;
        public CoreMiddleware(IEmailLogger emaillogger, IDatabaseLogger database, ITextFileLogger filelogger, IEventLogger eventlogger)
        { 
            this.emaillogger = emaillogger;
            this.eventlogger = eventlogger;
            this.database = database;
            this.filelogger = filelogger;
            this.eventlogger = eventlogger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (CriticalUserException err)
            {
                emaillogger.LogEmail(err.Message);

                eventlogger.LogEvent(err.Message);

                database.LogDatabase(err.Message);

                filelogger.Log(err.Message);
            }
        }
    }
}
