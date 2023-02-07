using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.IPL.Migrations.Message
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EukaryoteEukaryoteEukaryoteId = table.Column<int>(name: "Eukaryote_EukaryoteEukaryoteId", type: "int", nullable: false),
                    UserUserUserId = table.Column<int>(name: "User_UserUserId", type: "int", nullable: false),
                    DataTime = table.Column<DateTime>(name: "Data_Time", type: "datetime2", nullable: false),
                    DataLatitude = table.Column<long>(name: "Data_Latitude", type: "bigint", nullable: false),
                    DataLongitude = table.Column<long>(name: "Data_Longitude", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message_Likes");

            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
