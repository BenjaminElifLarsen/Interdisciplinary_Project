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

            migrationBuilder.CreateTable(
                name: "Animalia_Messages",
                columns: table => new
                {
                    AnimaliaId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageMessageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animalia_Messages", x => new { x.AnimaliaId, x.Id });
                    table.ForeignKey(
                        name: "FK_Animalia_Messages_Animalia_AnimaliaId",
                        column: x => x.AnimaliaId,
                        principalTable: "Animalia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plantae_Messages",
                columns: table => new
                {
                    PlantaeId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageMessageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantae_Messages", x => new { x.PlantaeId, x.Id });
                    table.ForeignKey(
                        name: "FK_Plantae_Messages_Plantae_PlantaeId",
                        column: x => x.PlantaeId,
                        principalTable: "Plantae",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animalia_Messages");

            migrationBuilder.DropTable(
                name: "Plantae_Messages");

            migrationBuilder.DropTable(
                name: "Animalia");

            migrationBuilder.DropTable(
                name: "Plantae");

            migrationBuilder.DropSequence(
                name: "EukaryoteSequence");
        }
    }
}
