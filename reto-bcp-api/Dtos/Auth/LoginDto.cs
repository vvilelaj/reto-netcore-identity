using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reto_bcp_api.Dtos.Auth
{
    public class LoginDto
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}
