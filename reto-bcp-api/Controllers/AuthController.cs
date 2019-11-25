using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using reto_bcp_api.Dtos;
using reto_bcp_api.Dtos.Auth;
using reto_bcp_api.Services.Interfaces;

namespace reto_bcp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult<GeneralResponse<string>> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var data = _authService.Login(loginDto);
                return GeneralResponse<string>.BuildOk(data);
            }
            catch (Exception ex)
            {
                // TODO :  call to logger
                return GeneralResponse<SecurityToken>.BuildBad("Error : No se pudo generar token.", (string)null);
            }
        }
    }
}