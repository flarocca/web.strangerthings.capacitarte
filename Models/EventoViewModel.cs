using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capacitarte.Models
{
    public class EventoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar una descripción.")]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Debe ingresar una fecha de inicio.")]
        [Display(Name = "Fecha de Inicio")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "Debe ingresar una fecha de fin.")]
        [Display(Name = "Fecha de Fin")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "Debe ingresar un horario de cursada.")]
        [Display(Name = "Hora")]
        public string Hora { get; set; }

        [Required(ErrorMessage = "Debe ingresar el costo del evento.")]
        [Display(Name = "Costo")]
        [Range(0, double.MaxValue, ErrorMessage = "Por favor ingrese un numero mayor a 0.")]
        public double Costo { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el aula donde se llevara a cabo el evento.")]
        [Display(Name = "Aula")]
        public int SelectedAulaId { get; set; }

        [Display(Name = "Aula")]
        public string SelectedAulaText { get; set; }
        public IEnumerable<SelectListItem> AulaList { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el instructor que dictara el evento.")]
        [Display(Name = "Instructor")]
        public int SelectedInstructorId { get; set; }

        [Display(Name = "Instructor")]
        public string SelectedInstructorText { get; set; }
        public IEnumerable<SelectListItem> InstructorList { get; set; }

        [Required(ErrorMessage = "Debe ingresar un estado para el evento.")]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Debe ingresar el presupuesto asignado al evento")]
        [Display(Name = "Presupuesto")]
        [Range(0, double.MaxValue, ErrorMessage = "Por favor ingrese un numero mayor a 0.")]
        public double Presupuesto { get; set; }
    }
}