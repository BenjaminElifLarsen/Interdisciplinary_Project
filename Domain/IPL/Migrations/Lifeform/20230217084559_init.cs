using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.IPL.Migrations.Lifeform
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "EukaryoteSequence");

            migrationBuilder.CreateTable(
                name: "Animalia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [EukaryoteSequence]"),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaximumOffspringsPerMating = table.Column<byte>(type: "tinyint", nullable: false),
                    MinimumOffspringsPerMating = table.Column<byte>(type: "tinyint", nullable: false),
                    IsBird = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animalia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plantae",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [EukaryoteSequence]"),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaximumHeight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantae", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animalia");

            migrationBuilder.DropTable(
                name: "Plantae");

            migrationBuilder.DropSequence(
                name: "EukaryoteSequence");
        }
    }
}
