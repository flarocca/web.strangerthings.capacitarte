using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capacitarte.Models
{
    public class Sede
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Display(Name = "Aulas")]
        public IEnumerable<Aula> Aulas { get; set; }
    }
}