using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal_TiendaNet.Migrations
{
    /// <inheritdoc />
    public partial class AgregadodeentidadPersonalizacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personalizaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackgroundColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LetterColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TiendaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personalizaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personalizaciones_Tienda_TiendaID",
                        column: x => x.TiendaID,
                        principalTable: "Tienda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personalizaciones_TiendaID",
                table: "Personalizaciones",
                column: "TiendaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personalizaciones");
        }
    }
}
