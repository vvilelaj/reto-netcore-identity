using System.Collections.Generic;
using reto_bcp_api.Dtos;
using reto_bcp_api.Persistance.Models;

namespace reto_bcp_api.Services.Interfaces
{
    public interface IAgenciaService
    {
        List<AgenciaDto> GetAll();
    }
}