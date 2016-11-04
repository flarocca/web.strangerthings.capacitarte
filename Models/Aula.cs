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
        [Range(1, int.MaxValue, ErrorMessage = "Por favor ingrese un numero mayor a 0.")]
        public int Cupo { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public int Estado { get; set; }

        [Required]
        [Display(Name = "Sede")]
        public Sede Sede { get; set; }

        public override string ToString()
        {
            return Descripcion + ", " + Sede.ToString();
        }
    }
}