using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaApp.Data.Migrations
{
    public partial class Teams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rating = table.Column<double>(nullable: false),
                    Wins = table.Column<int>(nullable: false),
                    Losses = table.Column<int>(nullable: false),
                    LastMatchTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LogoUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 208, 31, 32, 152, 95, 11, 61, 65, 185, 191, 116, 83, 228, 155, 194, 133, 135, 172, 194, 167, 42, 97, 15, 39, 189, 90, 248, 240, 17, 180, 212, 54, 138, 82, 204, 140, 205, 6, 168, 112, 155, 119, 228, 199, 199, 200, 244, 35, 101, 41, 128, 142, 240, 61, 119, 226, 87, 48, 173, 243, 178, 246, 146, 27 }, new byte[] { 66, 121, 107, 150, 101, 47, 134, 130, 148, 205, 48, 144, 74, 131, 163, 127, 203, 5, 155, 110, 178, 11, 149, 199, 141, 33, 45, 26, 49, 177, 23, 115, 242, 27, 208, 149, 18, 154, 199, 113, 123, 116, 107, 51, 71, 166, 101, 208, 42, 210, 48, 16, 173, 117, 146, 130, 208, 191, 127, 200, 86, 147, 66, 12, 166, 120, 137, 213, 123, 125, 230, 59, 57, 19, 230, 107, 43, 202, 186, 4, 219, 204, 179, 217, 184, 21, 91, 26, 5, 104, 123, 163, 89, 227, 23, 109, 23, 192, 142, 5, 59, 25, 123, 59, 73, 248, 195, 219, 91, 74, 72, 107, 132, 69, 9, 216, 186, 50, 152, 183, 211, 231, 181, 194, 44, 242, 36, 217 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 245, 143, 157, 194, 124, 5, 196, 92, 82, 12, 49, 125, 116, 122, 93, 196, 173, 155, 223, 184, 74, 213, 176, 57, 126, 192, 184, 114, 238, 125, 184, 27, 161, 19, 96, 93, 189, 192, 48, 85, 149, 236, 96, 132, 185, 160, 20, 71, 12, 68, 240, 60, 86, 54, 131, 228, 179, 163, 180, 63, 38, 116, 10, 69 }, new byte[] { 103, 26, 148, 69, 144, 80, 209, 196, 195, 68, 127, 41, 169, 30, 9, 158, 122, 122, 56, 115, 84, 66, 77, 54, 67, 85, 14, 203, 141, 217, 175, 82, 55, 185, 39, 226, 213, 196, 9, 84, 73, 126, 24, 151, 66, 73, 240, 200, 97, 19, 129, 197, 18, 103, 160, 106, 140, 160, 95, 70, 36, 183, 65, 34, 232, 85, 163, 30, 37, 43, 31, 117, 74, 10, 111, 18, 118, 81, 180, 38, 60, 246, 1, 178, 109, 147, 119, 63, 64, 0, 61, 108, 18, 49, 212, 65, 96, 75, 177, 116, 208, 164, 112, 254, 99, 185, 144, 101, 12, 14, 139, 59, 226, 89, 185, 174, 80, 247, 7, 167, 156, 39, 249, 59, 192, 158, 106, 80 } });
        }
    }
}
