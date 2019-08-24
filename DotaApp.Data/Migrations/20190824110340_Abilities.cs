using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaApp.Data.Migrations
{
    public partial class Abilities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AbilityName = table.Column<string>(nullable: true),
                    Behavior = table.Column<string>(nullable: true),
                    DamageType = table.Column<string>(nullable: true),
                    Pierce = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    ManaCost = table.Column<string>(nullable: true),
                    Cooldown = table.Column<string>(nullable: true),
                    HeroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abilities_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbilityAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(nullable: true),
                    Header = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Generated = table.Column<bool>(nullable: false),
                    AbilityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbilityAttributes_Abilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 80, 233, 91, 86, 204, 203, 110, 253, 107, 175, 29, 63, 143, 125, 217, 68, 212, 227, 101, 231, 90, 182, 93, 191, 42, 53, 44, 195, 178, 45, 141, 112, 133, 78, 80, 235, 215, 241, 166, 103, 103, 135, 218, 143, 59, 45, 30, 197, 173, 106, 137, 118, 84, 220, 217, 251, 104, 107, 17, 91, 222, 35, 32, 217 }, new byte[] { 231, 179, 46, 141, 52, 55, 202, 93, 140, 212, 98, 141, 12, 49, 30, 8, 108, 195, 97, 37, 41, 175, 118, 174, 243, 116, 212, 147, 132, 57, 214, 59, 97, 223, 189, 111, 40, 70, 244, 16, 83, 164, 12, 40, 169, 249, 76, 101, 247, 223, 80, 54, 185, 155, 211, 126, 251, 61, 227, 187, 237, 120, 240, 243, 60, 127, 77, 164, 148, 238, 71, 217, 6, 188, 184, 215, 15, 167, 12, 95, 51, 56, 196, 45, 178, 30, 113, 90, 34, 114, 20, 253, 136, 190, 108, 62, 90, 58, 158, 244, 19, 69, 29, 163, 24, 17, 211, 196, 208, 201, 63, 203, 205, 140, 217, 85, 154, 121, 232, 36, 4, 22, 249, 217, 233, 155, 255, 184 } });

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_HeroId",
                table: "Abilities",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_AbilityAttributes_AbilityId",
                table: "AbilityAttributes",
                column: "AbilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbilityAttributes");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 228, 116, 111, 117, 56, 67, 235, 66, 25, 55, 106, 94, 162, 129, 70, 33, 37, 161, 127, 211, 72, 5, 173, 85, 43, 154, 196, 208, 13, 244, 3, 174, 191, 105, 100, 204, 54, 51, 11, 209, 195, 144, 35, 211, 21, 225, 167, 241, 171, 51, 176, 221, 111, 199, 208, 222, 53, 201, 161, 35, 21, 30, 92, 97 }, new byte[] { 179, 181, 118, 104, 219, 183, 119, 11, 22, 69, 81, 6, 23, 107, 142, 130, 143, 191, 85, 216, 174, 176, 183, 204, 58, 123, 64, 61, 213, 62, 59, 235, 57, 29, 95, 108, 83, 205, 194, 196, 248, 48, 170, 176, 43, 126, 25, 162, 211, 175, 38, 13, 195, 187, 236, 43, 174, 22, 155, 61, 240, 64, 105, 55, 185, 187, 228, 163, 206, 2, 148, 213, 89, 100, 103, 67, 162, 103, 101, 170, 46, 49, 233, 76, 73, 18, 198, 0, 135, 201, 11, 25, 157, 106, 21, 190, 69, 79, 89, 230, 210, 135, 243, 129, 48, 218, 170, 171, 28, 168, 56, 52, 208, 116, 240, 169, 224, 243, 60, 124, 82, 47, 159, 112, 16, 55, 138, 144 } });
        }
    }
}
