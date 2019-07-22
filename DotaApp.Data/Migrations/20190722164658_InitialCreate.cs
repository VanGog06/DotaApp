using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaApp.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentityRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_IdentityRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "IdentityRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IdentityRoles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "IdentityRoles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, "admin@dota.app", "Admin", "Admin", new byte[] { 156, 224, 143, 246, 218, 172, 128, 54, 105, 235, 170, 161, 175, 231, 12, 81, 98, 92, 209, 113, 254, 86, 64, 205, 152, 254, 237, 56, 112, 170, 202, 254, 152, 0, 198, 0, 214, 144, 211, 195, 98, 13, 109, 46, 233, 105, 207, 237, 14, 220, 17, 12, 179, 95, 49, 18, 247, 192, 27, 46, 76, 58, 183, 235 }, new byte[] { 96, 196, 88, 233, 164, 194, 31, 32, 155, 210, 194, 70, 174, 231, 19, 241, 207, 198, 233, 186, 83, 112, 28, 56, 215, 167, 78, 201, 86, 127, 126, 216, 138, 126, 16, 71, 106, 87, 19, 111, 228, 219, 124, 119, 121, 5, 185, 121, 70, 231, 201, 130, 175, 148, 231, 42, 210, 181, 79, 156, 250, 255, 144, 137, 166, 189, 190, 46, 254, 19, 174, 106, 12, 175, 7, 72, 253, 35, 3, 138, 66, 182, 26, 105, 217, 71, 194, 175, 126, 121, 119, 154, 157, 104, 193, 166, 245, 66, 97, 113, 45, 250, 81, 215, 70, 206, 7, 111, 252, 130, 232, 20, 246, 224, 2, 159, 143, 88, 120, 114, 197, 77, 34, 75, 60, 248, 105, 33 }, "admin" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "IdentityRoles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
