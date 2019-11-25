using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using reto_bcp_api.Dtos;
using reto_bcp_api.Dtos.CuentasUsuario;
using reto_bcp_api.Persistance.Models;
using reto_bcp_api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reto_bcp_api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasUsuarioController : ControllerBase
    {
        private readonly ICuentasUsuarioService _cuentasUsuarioService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cuentasUsuarioService"></param>
        public CuentasUsuarioController(ICuentasUsuarioService cuentasUsuarioService)
        {
            _cuentasUsuarioService = cuentasUsuarioService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cuentaUsuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]CuentaUsuarioDto cuentaUsuario)
        {
            try
            {
                _cuentasUsuarioService.Create(cuentaUsuario);
                return Ok();
            }
            catch (Exception ex)
            {
                // Todo : call to logger
                return BadRequest();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpDelete("{usuario}")]
        public IActionResult Delete(string usuario)
        {
            try
            {
                _cuentasUsuarioService.Delete(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                // Todo : call to logger
                return BadRequest();
            }
        }
    }
}
