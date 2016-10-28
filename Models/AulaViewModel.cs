using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capacitarte.Models
{
    public class AulaViewModel
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
        public int SelectedSedeId { get; set; }
        public IEnumerable<SelectListItem> SedeList { get; set; }

        internal Aula GetNewAula(int id, Sede sede)
        {
            return new Aula()
            {
                Id = id,
                Descripcion = Descripcion,
                Cupo = Cupo,
                Estado = Estado,
                Sede = sede
            };
        }
    }
}