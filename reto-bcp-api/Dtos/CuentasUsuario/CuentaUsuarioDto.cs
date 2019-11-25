using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reto_bcp_api.Dtos.CuentasUsuario
{
    public class CuentaUsuarioDto
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string ConfirmarContrasena { get; set; }
    }
}
