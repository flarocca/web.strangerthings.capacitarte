using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capacitarte.Models
{
    public class InstructorViewModel
    {
        public List<InstructorSelectedViewModel> Instructors { get; set; }
        public List<int> SelectedUsers { get; set; }
    }

    public class InstructorSelectedViewModel
    {
        [Display(Name = "Usuario_ID")]
        public int Usuario_ID { get; set; }

        [Display(Name = "Usuario")]
        public string Descripcion { get; set; }

        [Display(Name = "Asignar rol de Instructor")]
        public bool Selected { get; set; }
    }
}