using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capacitarte.Models
{
    public class Aula
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Cupo")]
        public int Cupo { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public int Estado { get; set; }

        [Required]
        [Display(Name = "Sede")]
        public Sede Sede { get; set; }
    }
}