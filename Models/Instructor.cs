﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capacitarte.Models
{
    public class Instructor
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public Usuario Usuario { get; set; }

        [Required]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        [Required]
        [Display(Name = "Gerencia")]
        public string Gerencia { get; set; }

        [Required]
        [Display(Name = "Jefatura")]
        public string Jefatura { get; set; }

        [Required]
        [Display(Name = "Convenio")]
        public string Convenio { get; set; }
    }
}