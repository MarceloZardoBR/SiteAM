using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiapAM.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public String NomeUsuario { get; set; }
        public String EmailUsuario { get; set; }
        public String SenhaUsuario { get; set; }
    }
}