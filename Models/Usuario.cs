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
        public Usuario ()
        {
            Roles = new List<RolPorUsuario>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Empleado")]
        [Index(IsUnique = true)]
        public Empleado Empleado { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Roles")]
        public List<RolPorUsuario> Roles { get; set; }

        public override string ToString()
        {
            return Empleado.ToString();
        }
    }
}