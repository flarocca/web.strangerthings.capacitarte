using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capacitarte.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Fecha de Inicio")]
        public DateTime FechaInicio { get; set; }

        [Required]
        [Display(Name = "Fecha de Fin")]
        public DateTime FechaFin { get; set; }

        [Required]
        [Display(Name = "Hora")]
        public string Hora { get; set; }

        [Required]
        [Display(Name = "Costo")]
        public double Costo { get; set; }

        [Required]
        [Display(Name = "Aula")]
        public Aula Aula { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Required]
        [Display(Name = "Presupuesto")]
        public double Presupuesto { get; set; }

        /*
+ ListaDeInvitados
+ ListaDeParticipantes

+Plantilla de Invitación
         * */
    }
}