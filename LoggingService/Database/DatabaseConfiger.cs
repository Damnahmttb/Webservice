using LoggingService.Database.Dbcontext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingService.Database
{
    public static  class DatabaseConfiger
    {
        public static void ProductDatabase(this IServiceCollection collection)
        {
            collection.AddDbContext<LoggerDatabaseContext>(opt => opt.UseSqlServer("Server=tcp:sampledbdb.database.windows.net,1433;Initial Catalog=stopthisLastATLNDSERVER03012024;Persist Security Info=False;User ID=Ahmet;Password=636831Aa;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
        }
    }
}
