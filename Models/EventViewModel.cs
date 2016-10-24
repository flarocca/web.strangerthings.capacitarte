using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capacitarte.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción del evento no puede ser nula.")]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        public int Creator { get; set; }
        public List<int> Guests { get; set; }
        public List<int> Participants { get; set; }

        [Required(ErrorMessage = "La fecha de incio no puede ser nula.")]
        [Display(Name = "Fecha de Inicio")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "La fecha de finalización no puede ser nula.")]
        [Display(Name = "Fecha de Finalización")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EndDate { get; set; }

        public string Hour { get; set; }
        public int Cost { get; set; }
        public string Branch { get; set; }
        public string Room { get; set; }
        public int InvitationTemplate { get; set; }
        public string State { get; set; }
        public int Budget { get; set; }

        public override string ToString()
        {
            return Description + " (" + StartDate.ToShortDateString() + " - " + EndDate.ToShortDateString() + ")";
        }
    }
}