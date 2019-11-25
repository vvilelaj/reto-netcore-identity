using System.Collections.Generic;
using reto_bcp_api.Persistance.Models;

namespace reto_bcp_api.Persistance.Repositories.Interfaces
{
    public interface IAgenciaRepository
    {
        void DeleteByAgenciaId(Agencia agencia);
        List<Agencia> GetAll();
        List<Agencia> GetBy(string agencia);
        Agencia GetByAgenciaId(int agenciaId);
        Agencia SaveAgencia(Agencia agencia);
        Agencia Update(Agencia agencia);
    }
}