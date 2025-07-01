using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal_TiendaNet.Migrations
{
    /// <inheritdoc />
    public partial class AgregadodeentidadPlantilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plantillas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackgroundColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LetterColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantillas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plantillas");
        }
    }
}
