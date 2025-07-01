using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal_TiendaNet.Migrations
{
    /// <inheritdoc />
    public partial class AgregadodeentidadCategoriaTienda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaTienda_Tienda_TiendaId",
                table: "CategoriaTienda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriaTienda",
                table: "CategoriaTienda");

            migrationBuilder.RenameTable(
                name: "CategoriaTienda",
                newName: "CategoriaTiendas");

            migrationBuilder.RenameIndex(
                name: "IX_CategoriaTienda_TiendaId",
                table: "CategoriaTiendas",
                newName: "IX_CategoriaTiendas_TiendaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriaTiendas",
                table: "CategoriaTiendas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaTiendas_Tienda_TiendaId",
                table: "CategoriaTiendas",
                column: "TiendaId",
                principalTable: "Tienda",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaTiendas_Tienda_TiendaId",
                table: "CategoriaTiendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriaTiendas",
                table: "CategoriaTiendas");

            migrationBuilder.RenameTable(
                name: "CategoriaTiendas",
                newName: "CategoriaTienda");

            migrationBuilder.RenameIndex(
                name: "IX_CategoriaTiendas_TiendaId",
                table: "CategoriaTienda",
                newName: "IX_CategoriaTienda_TiendaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriaTienda",
                table: "CategoriaTienda",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaTienda_Tienda_TiendaId",
                table: "CategoriaTienda",
                column: "TiendaId",
                principalTable: "Tienda",
                principalColumn: "Id");
        }
    }
}
