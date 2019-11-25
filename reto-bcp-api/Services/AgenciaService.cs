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
                    .Select(x => GetDto(x))
                    .ToList();
        }

        private AgenciaDto GetDto(Agencia agencia)
        {
            return new AgenciaDto
            {
                Agencia = agencia.Descripcion,
                Distrito = agencia.Distrito,
                Provincia = agencia.Provincia,
                Departamento = agencia.Departamento,
                Direccion = agencia.Direccion,
                Lat = agencia.Latitud,
                Lon = agencia.Longitud
            };
        }
        public List<AgenciaDto> GetBy(string agencia)
        {
            if (string.IsNullOrEmpty(agencia)) return GetAll();

            return agenciaRepository
                    .GetBy(agencia)
                    .Select(x => GetDto(x))
                    .ToList();
        }

        public AgenciaDto Save(int agenciaId, AgenciaDto agencia)
        {
            if (agenciaId < 0) throw new ArgumentOutOfRangeException("agenciaId");
            if (agencia == null) throw new ArgumentNullException("agencia");

            if (agenciaId != 0)
            {
                var agenciaToUpdate = this.agenciaRepository.GetByAgenciaId(agenciaId);

                if (agenciaToUpdate == null)
                    throw new Exception($"AgenciaService.Save : Agencia with agencia id equals to {agenciaId} does not exists.");

                agenciaToUpdate = GetModel(agenciaId, agencia);
                this.agenciaRepository.Update(agenciaToUpdate);
                return GetDto(agenciaToUpdate);
            }
            else
            {
                var agenciaToRegister = GetModel(0, agencia);
                this.agenciaRepository.SaveAgencia(agenciaToRegister);
                return GetDto(agenciaToRegister);
            }

        }

        private Agencia GetModel(int agenciaId, AgenciaDto agencia)
        {
            return new Agencia
            {
                AgenciaId = agenciaId,
                Descripcion = agencia.Agencia,
                Distrito = agencia.Distrito,
                Provincia = agencia.Provincia,
                Departamento = agencia.Departamento,
                Direccion = agencia.Direccion,
                Latitud = agencia.Lat,
                Longitud = agencia.Lon
            };
        }
    }
}
