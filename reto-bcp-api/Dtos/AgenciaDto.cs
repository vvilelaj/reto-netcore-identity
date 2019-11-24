using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reto_bcp_api.Dtos
{
    public class AgenciaDto
    {
        public string Agencia { get; set; }
        public string Distrito { get; set; }
        public string Provincia { get; set; }
        public string Departamento { get; set; }
        public string Direccion { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
    }
}
