using reto_bcp_api.Dtos;
using reto_bcp_api.Persistance.Models;
using reto_bcp_api.Persistance.Repositories.Interfaces;
using reto_bcp_api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reto_bcp_api.Services
{
    public class AgenciaService : IAgenciaService
    {
        private readonly IAgenciaRepository agenciaRepository;
        public AgenciaService(IAgenciaRepository agenciaRepository)
        {
            this.agenciaRepository = agenciaRepository;
        }
        public List<AgenciaDto> GetAll()
        {
            return agenciaRepository
                    .GetAll()
                    .Select(x => new AgenciaDto
                    {
                        Agencia = x.Descripcion,
                        Distrito = x.Distrito,
                        Provincia = x.Provincia,
                        Departamento = x.Departamento,
                        Direccion = x.Direccion,
                        Lat = x.Latitud,
                        Lon = x.Longitud
                    })
                    .ToList();
        }
    }
}
