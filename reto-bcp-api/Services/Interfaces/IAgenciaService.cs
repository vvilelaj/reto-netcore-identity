using System.Collections.Generic;
using reto_bcp_api.Dtos;
using reto_bcp_api.Persistance.Models;

namespace reto_bcp_api.Services.Interfaces
{
    public interface IAgenciaService
    {
        List<AgenciaDto> GetAll();
        List<AgenciaDto> GetBy(string agencia);
        AgenciaDto Save(int agenciaId, AgenciaDto agencia);
    }
}