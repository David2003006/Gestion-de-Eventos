using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_de_Eventos.Migrations
{
    /// <inheritdoc />
    public partial class addSeguidores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seguidores",
                columns: table => new
                {
                    IdSeguidor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdOrganizador = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "int", nullable: true),
                    OrganizadorIdOganizador = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguidores", x => x.IdSeguidor);
                    table.ForeignKey(
                        name: "FK_Seguidores_Organizadores_OrganizadorIdOganizador",
                        column: x => x.OrganizadorIdOganizador,
                        principalTable: "Organizadores",
                        principalColumn: "IdOganizador");
                    table.ForeignKey(
                        name: "FK_Seguidores_Usuarios_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Seguidores_OrganizadorIdOganizador",
                table: "Seguidores",
                column: "OrganizadorIdOganizador");

            migrationBuilder.CreateIndex(
                name: "IX_Seguidores_UsuarioIdUsuario",
                table: "Seguidores",
                column: "UsuarioIdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seguidores");
        }
    }
}
