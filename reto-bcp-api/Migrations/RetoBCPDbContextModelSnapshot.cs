﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using reto_bcp_api.Persistance;

namespace reto_bcp_api.Migrations
{
    [DbContext(typeof(RetoBCPDbContext))]
    partial class RetoBCPDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("reto_bcp_api.Persistance.Models.Agencia", b =>
                {
                    b.Property<int>("AgenciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AgenciaId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Departamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Departamento")
                        .HasMaxLength(500)
                        .HasDefaultValue("");

                    b.Property<string>("Descripcion")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Descripcion")
                        .HasMaxLength(500)
                        .HasDefaultValue("");

                    b.Property<string>("Direccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Direccion")
                        .HasMaxLength(500)
                        .HasDefaultValue("");

                    b.Property<string>("Distrito")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Distrito")
                        .HasMaxLength(500)
                        .HasDefaultValue("");

                    b.Property<decimal>("Latitud")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Latitud")
                        .HasColumnType("decimal(18,8)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("Longitud")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Longitud")
                        .HasColumnType("decimal(18,8)")
                        .HasDefaultValue(0m);

                    b.Property<string>("Provincia")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Provincia")
                        .HasMaxLength(500)
                        .HasDefaultValue("");

                    b.HasKey("AgenciaId")
                        .HasName("AgenciaId");

                    b.ToTable("Agencia");
                });
#pragma warning restore 612, 618
        }
    }
}
