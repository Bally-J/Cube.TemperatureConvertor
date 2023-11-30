using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube.Core.Models
{
    public class AuditLog
    {
        public string UserName { get; set; }
        public DateTime RecordedDateUTC { get; set; }
        public string Data { get; set; }
    }
}
