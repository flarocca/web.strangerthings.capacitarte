using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capacitarte.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Empleado")]
        [Index(IsUnique = true)]
        public Empleado Empleado { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Roles")]
        public IEnumerable<RolPorUsuario> Roles { get; set; }
    }
}