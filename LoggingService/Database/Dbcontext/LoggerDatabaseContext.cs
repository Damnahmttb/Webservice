using LoggingService.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingService.Database.Dbcontext
{
    public class LoggerDatabaseContext:DbContext
    {
        public LoggerDatabaseContext(DbContextOptions<LoggerDatabaseContext>opts):base(opts)
        {
            
        }
        public DbSet<DatabaseHandlerEntity> loggerTable { get; set; }
    }
}
