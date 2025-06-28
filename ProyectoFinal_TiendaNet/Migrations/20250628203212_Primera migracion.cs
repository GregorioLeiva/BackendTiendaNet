using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoFinal_TiendaNet.Migrations
{
    /// <inheritdoc />
    public partial class Primeramigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "Contraseña", "Email", "FechaRegistro", "Nombre", "Rol", "Username" },
                values: new object[,]
                {
                    { 1, "Leiva", "12345678", "gleiva@frsn.utn.edu.ar", new DateTime(2025, 6, 28, 17, 32, 10, 737, DateTimeKind.Local).AddTicks(1055), "Gregorio", "Administrador", "gleiva" },
                    { 2, "Leiva", "12345678", "gleiva@frsn.utn.edu.ar", new DateTime(2025, 6, 28, 17, 32, 10, 738, DateTimeKind.Local).AddTicks(9585), "Gregorio", "Vendedor", "gregorio" },
                    { 3, "Leiva", "12345678", "gleiva@frsn.utn.edu.ar", new DateTime(2025, 6, 28, 17, 32, 10, 738, DateTimeKind.Local).AddTicks(9602), "Gregorio", "Comprador", "goyo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
