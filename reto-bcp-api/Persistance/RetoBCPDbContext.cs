using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using reto_bcp_api.Persistance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reto_bcp_api.Persistance
{
    /// <summary>
    /// 
    /// </summary>
    public class RetoBCPDbContext : IdentityDbContext<RetoBcpUser>
    {
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Agencia> Agencias { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public RetoBCPDbContext(DbContextOptions<RetoBCPDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
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
                .HasColumnName("Latitud")
                .HasColumnType("decimal(18,8)")
                .HasDefaultValue(0.0);
            //
            modelBuilder.Entity<Agencia>().Property(x => x.Longitud)
                .HasColumnName("Longitud")
                .HasColumnType("decimal(18,8)")
                .HasDefaultValue(0.0);


            base.OnModelCreating(modelBuilder);
        }
    }
}
