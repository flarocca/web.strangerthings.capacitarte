using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capacitarte.Models
{
    public class ModifyInstructorViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
    }
}