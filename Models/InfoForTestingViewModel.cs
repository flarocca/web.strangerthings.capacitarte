using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capacitarte.Models
{
    public class InfoForTestingViewModel
    {
        public List<Empleado> Empleados { get; set; }

        public List<Rol> Roles { get; set; }
   
        public List<Usuario> Usuarios { get; set; }
    }
}