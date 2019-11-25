using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebSockets.Internal;
using reto_bcp_api.Dtos;
using reto_bcp_api.Services.Interfaces;

namespace reto_bcp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenciasController : ControllerBase
    {
        public readonly IAgenciaService agenciaService;

        public AgenciasController(IAgenciaService agenciaService)
        {
            this.agenciaService = agenciaService;
        }

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
