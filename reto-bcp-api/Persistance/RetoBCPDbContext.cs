using Microsoft.EntityFrameworkCore;
using reto_bcp_api.Persistance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reto_bcp_api.Persistance
{
    public class RetoBCPDbContext : DbContext
    {
        public DbSet<Agencia> Agencias { get; set; }

        public RetoBCPDbContext(DbContextOptions<RetoBCPDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agencia>()
                .ToTable("Agencia");

            modelBuilder.Entity<Agencia>()
                .HasKey(x => x.AgenciaId)
                .HasName("AgenciaId")
                ;

            modelBuilder.Entity<Agencia>().Property(x => x.AgenciaId)
                .HasColumnName("AgenciaId").IsRequired(true);
            //
            modelBuilder.Entity<Agencia>().Property(x => x.Descripcion)
                .HasColumnName("Descripcion").HasDefaultValue(string.Empty).HasMaxLength(500);
            //
            modelBuilder.Entity<Agencia>().Property(x => x.Distrito)
                .HasColumnName("Distrito").HasDefaultValue(string.Empty).HasMaxLength(500);
            //
            modelBuilder.Entity<Agencia>().Property(x => x.Provincia)
                .HasColumnName("Provincia").HasDefaultValue(string.Empty).HasMaxLength(500);
            //
            modelBuilder.Entity<Agencia>().Property(x => x.Departamento)
                .HasColumnName("Departamento").HasDefaultValue(string.Empty).HasMaxLength(500);
            //
            modelBuilder.Entity<Agencia>().Property(x => x.Direccion)
                .HasColumnName("Direccion").HasDefaultValue(string.Empty).HasMaxLength(500);
            //
            modelBuilder.Entity<Agencia>().Property(x => x.Latitud)
                .HasColumnName("Latitud").HasDefaultValue(0.0);
            //
            modelBuilder.Entity<Agencia>().Property(x => x.Longitud)
                .HasColumnName("Longitud").HasDefaultValue(0.0);


            base.OnModelCreating(modelBuilder);
        }
    }
}
