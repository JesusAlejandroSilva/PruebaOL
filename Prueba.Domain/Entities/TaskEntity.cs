using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Domain.Entities
{
    public class TaskEntity
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Title")]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Column("Description")]
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;

        [Column("Status")]
        [MaxLength(100)]
        public string Status { get; set; } = "Pending";
        [Column("AssignedUserId")]
        public Guid AssignedUserId { get; set; }
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
