using System.ComponentModel.DataAnnotations;

namespace Cube.Data.Entities
{
    public class AuditTrail
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public DateTime RecordedDateUTC { get; set; }

        [Required]
        public string Data { get; set; }
    }
}