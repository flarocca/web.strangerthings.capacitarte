﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capacitarte.Models
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
    }

    public class RolPorUsuario
    {
        [Key, Column(Order = 0)]
        public int Usuario_ID { get; set; }

        [ForeignKey("Usuario_ID")]
        public Usuario Usuario { get; set; }

        [Key, Column(Order = 1)]
        public int Rol_ID { get; set; }

        [ForeignKey("Rol_ID")]
        public Rol Rol { get; set; }
    }
}