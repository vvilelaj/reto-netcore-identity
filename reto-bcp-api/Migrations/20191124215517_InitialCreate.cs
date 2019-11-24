using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace reto_bcp_api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencia",
                columns: table => new
                {
                    AgenciaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 500, nullable: true, defaultValue: ""),
                    Distrito = table.Column<string>(maxLength: 500, nullable: true, defaultValue: ""),
                    Provincia = table.Column<string>(maxLength: 500, nullable: true, defaultValue: ""),
                    Departamento = table.Column<string>(maxLength: 500, nullable: true, defaultValue: ""),
                    Direccion = table.Column<string>(maxLength: 500, nullable: true, defaultValue: ""),
                    Latitud = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    Longitud = table.Column<decimal>(nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AgenciaId", x => x.AgenciaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agencia");
        }
    }
}
