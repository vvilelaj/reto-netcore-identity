using reto_bcp_api.Persistance.Models;
using reto_bcp_api.Persistance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reto_bcp_api.Persistance.Repositories
{
    public class AgenciaRepository : IAgenciaRepository
    {
        private readonly RetoBCPDbContext dbContext;

        public AgenciaRepository(RetoBCPDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Agencia> GetAll()
        {
            return this.dbContext.Agencias.ToList();
        }

        public List<Agencia> GetBy(string agencia)
        {
            return this.dbContext.Agencias.Where(x => x.Descripcion == agencia).ToList();
        }

        public Agencia GetByAgenciaId(int agenciaId)
        {
            return this.dbContext.Agencias.SingleOrDefault(x => x.AgenciaId == agenciaId);
        }

        public Agencia SaveAgencia(Agencia agencia)
        {
            this.dbContext.Agencias.Add(agencia);
            this.dbContext.SaveChanges();
            return agencia;
        }

        public Agencia Update(Agencia agencia)
        {
            this.dbContext.Agencias.Update(agencia);
            this.dbContext.SaveChanges();
            return agencia;
        }

        public void DeleteByAgenciaId(Agencia agencia)
        {
            this.dbContext.Agencias.Remove(agencia);
        }

    }
}
