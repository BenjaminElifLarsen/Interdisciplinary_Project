using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
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
                    TotalObservationTimes = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
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
                    TotalObservationTimes = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    MaximumHeight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantae", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameFirstName = table.Column<string>(name: "Name_FirstName", type: "nvarchar(max)", nullable: false),
                    NameLastName = table.Column<string>(name: "Name_LastName", type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EukaryoteId = table.Column<int>(type: "int", nullable: false),
                    DataTime = table.Column<DateTime>(name: "Data_Time", type: "datetime2", nullable: false),
                    DataLatitude = table.Column<long>(name: "Data_Latitude", type: "bigint", nullable: false),
                    DataLongitude = table.Column<long>(name: "Data_Longitude", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Likes",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Likes", x => new { x.UserId, x.Id });
                    table.ForeignKey(
                        name: "FK_User_Likes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message_Likes",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message_Likes", x => new { x.MessageId, x.Id });
                    table.ForeignKey(
                        name: "FK_Message_Likes_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_EukaryoteId",
                table: "Messages",
                column: "EukaryoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animalia");

            migrationBuilder.DropTable(
                name: "Message_Likes");

            migrationBuilder.DropTable(
                name: "Plantae");

            migrationBuilder.DropTable(
                name: "User_Likes");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropSequence(
                name: "EukaryoteSequence");
        }
    }
}
