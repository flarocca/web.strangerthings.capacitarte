using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capacitarte.Models
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
    }

    public class RolPorUsuario
    {
        [Key]
        [Display(Name = "Usuario")]
        public Usuario Usuario { get; set; }

        [Key]
        [Display(Name = "Rol")]
        public Rol Rol { get; set; }
    }
}