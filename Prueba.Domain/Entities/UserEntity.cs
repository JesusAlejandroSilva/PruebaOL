using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Domain.Entities
{
    public class UserEntity
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Column("Email")]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Column("PasswordHash")]
        [MaxLength(100)]
        public string PasswordHash { get; set; } = string.Empty;

        [Column("Role")]
        [MaxLength(100)]
        public string Role { get; set; } = "User";
    }
}
