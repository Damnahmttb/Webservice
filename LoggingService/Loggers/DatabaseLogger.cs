using LoggingService.Database.Dbcontext;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingService.Loggers
{
    public interface IDatabaseLogger
    {
        bool LogDatabase(string message);
    }

    public class DatabaseLogger : IDatabaseLogger
    {
        LoggerDatabaseContext context;
        string connectionString = "YourConnectionStringHere"; // Veritabanı bağlantı dizesi
        string tableName = "Logs"; // Logların kaydedileceği tablo adı
       private readonly ILogger log;
        public DatabaseLogger(LoggerDatabaseContext context)
        {
            this.context = context;
            //log = new LoggerConfiguration().WriteTo.MSSqlServer(connectionString, tableName, autoCreateSqlTable :true).CreateLogger();
        }

        public bool LogDatabase(string message)
        {
            log.Information(message);
            //Manuel Olaark Sadece Kaydetme
            EntityEntry entry=context.loggerTable.Add(new Database.Entities.DatabaseHandlerEntity() {Message=message });
            if (entry.State==Microsoft.EntityFrameworkCore.EntityState.Added)
            {
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }

}
