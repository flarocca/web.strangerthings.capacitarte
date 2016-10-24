using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capacitarte.Models
{
    public class ModifyInstructorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del instructor debe contener algún valor.")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido del instructor debe contener algún valor.")]
        [Display(Name = "Apellido")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "La dirección del instructor debe contener algún valor.")]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Required(ErrorMessage = "La gerencia del instructor debe contener algún valor.")]
        [Display(Name = "Gerencia")]
        public string Department { get; set; }

        [Required(ErrorMessage = "La jefatura del instructor debe contener algún valor.")]
        [Display(Name = "Jefatura")]
        public string Subdepartment { get; set; }


    }
}