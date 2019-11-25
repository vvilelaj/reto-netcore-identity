using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using reto_bcp_api.Dtos;
using reto_bcp_api.Services.Interfaces;

namespace reto_bcp_api.Controllers
{
    /// <summary>
    /// Controller para exponer los metodos del recurso Agencias
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AgenciasController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly IAgenciaService agenciaService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="agenciaService"></param>
        public AgenciasController(IAgenciaService agenciaService)
        {
            this.agenciaService = agenciaService;
        }

        /// <summary>
        /// Devuelve un listado de las agencias
        /// </summary>
        /// <param name="agencia">Nombre de Agencia</param>
        /// <returns>Intancia de GeneralResponse con informacion del listado de agencia</returns>
        [HttpGet]
        public ActionResult<GeneralResponse<List<AgenciaDto>>> Get(string agencia)
        {
            try
            {
                var data = agenciaService.GetBy(agencia);
                return GeneralResponse<List<AgenciaDto>>.BuildOk(data);
            }
            catch (Exception ex)
            {
                // Todo : call to logger
                return GeneralResponse<List<AgenciaDto>>.BuildBad(Common.Constants.GeneralError, (List<AgenciaDto>)null);
            }
        }

        /// <summary>
        /// Permite registar una agencia
        /// </summary>
        /// <param name="agencia">Instancia de AgenciaDTO</param>
        /// <returns>Intancia de GeneralResponse con informacion de la agencia</returns>
        [HttpPost]
        public ActionResult<GeneralResponse<AgenciaDto>> Post([FromBody] AgenciaDto agencia)
        {
            try
            {
                var data = agenciaService.Save(0, agencia);
                return GeneralResponse<AgenciaDto>.BuildOk(data);
            }
            catch (Exception ex)
            {
                // Todo : call to logger
                return GeneralResponse<AgenciaDto>.BuildBad(Common.Constants.GeneralError, (AgenciaDto)null);
            }
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
