using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_de_Eventos.Migrations
{
    /// <inheritdoc />
    public partial class addSeguirEventoHistorial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ubicacion",
                table: "Eventos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Historial",
                columns: table => new
                {
                    IdHistorial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCompra = table.Column<int>(type: "int", nullable: false),
                    Asistio = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historial", x => x.IdHistorial);
                    table.ForeignKey(
                        name: "FK_Historial_IngresarComprarBoletos_IdCompra",
                        column: x => x.IdCompra,
                        principalTable: "IngresarComprarBoletos",
                        principalColumn: "IdCompra",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SeguirEventos",
                columns: table => new
                {
                    IdSeguirEvento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEvento = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeguirEventos", x => x.IdSeguirEvento);
                    table.ForeignKey(
                        name: "FK_SeguirEventos_Eventos_IdEvento",
                        column: x => x.IdEvento,
                        principalTable: "Eventos",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeguirEventos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Historial_IdCompra",
                table: "Historial",
                column: "IdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_SeguirEventos_IdEvento",
                table: "SeguirEventos",
                column: "IdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_SeguirEventos_IdUsuario",
                table: "SeguirEventos",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historial");

            migrationBuilder.DropTable(
                name: "SeguirEventos");

            migrationBuilder.DropColumn(
                name: "Ubicacion",
                table: "Eventos");
        }
    }
}
