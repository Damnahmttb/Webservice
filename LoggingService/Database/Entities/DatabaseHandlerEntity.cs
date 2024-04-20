using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingService.Database.Entities
{
    public class DatabaseHandlerEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Message { get; set; }
    }
}
