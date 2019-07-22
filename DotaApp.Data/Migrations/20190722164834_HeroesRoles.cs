using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaApp.Data.Migrations
{
    public partial class HeroesRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PrimaryAttribute = table.Column<string>(nullable: true),
                    AttackType = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    BaseHealth = table.Column<int>(nullable: false),
                    BaseHealthRegen = table.Column<double>(nullable: true),
                    BaseMana = table.Column<int>(nullable: false),
                    BaseManaRegen = table.Column<double>(nullable: false),
                    BaseArmor = table.Column<double>(nullable: false),
                    BaseMr = table.Column<int>(nullable: false),
                    BaseAttackMin = table.Column<int>(nullable: false),
                    BaseAttackMax = table.Column<int>(nullable: false),
                    BaseStrength = table.Column<int>(nullable: false),
                    BaseAgility = table.Column<int>(nullable: false),
                    BaseIntellect = table.Column<int>(nullable: false),
                    StrengthGain = table.Column<double>(nullable: false),
                    AgilityGain = table.Column<double>(nullable: false),
                    IntellectGain = table.Column<double>(nullable: false),
                    AttackRange = table.Column<int>(nullable: false),
                    ProjectileSpeed = table.Column<int>(nullable: false),
                    AttackRate = table.Column<double>(nullable: false),
                    MoveSpeed = table.Column<int>(nullable: false),
                    TurnRate = table.Column<double>(nullable: false),
                    Legs = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeroRole",
                columns: table => new
                {
                    HeroId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroRole", x => new { x.HeroId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_HeroRole_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 228, 116, 111, 117, 56, 67, 235, 66, 25, 55, 106, 94, 162, 129, 70, 33, 37, 161, 127, 211, 72, 5, 173, 85, 43, 154, 196, 208, 13, 244, 3, 174, 191, 105, 100, 204, 54, 51, 11, 209, 195, 144, 35, 211, 21, 225, 167, 241, 171, 51, 176, 221, 111, 199, 208, 222, 53, 201, 161, 35, 21, 30, 92, 97 }, new byte[] { 179, 181, 118, 104, 219, 183, 119, 11, 22, 69, 81, 6, 23, 107, 142, 130, 143, 191, 85, 216, 174, 176, 183, 204, 58, 123, 64, 61, 213, 62, 59, 235, 57, 29, 95, 108, 83, 205, 194, 196, 248, 48, 170, 176, 43, 126, 25, 162, 211, 175, 38, 13, 195, 187, 236, 43, 174, 22, 155, 61, 240, 64, 105, 55, 185, 187, 228, 163, 206, 2, 148, 213, 89, 100, 103, 67, 162, 103, 101, 170, 46, 49, 233, 76, 73, 18, 198, 0, 135, 201, 11, 25, 157, 106, 21, 190, 69, 79, 89, 230, 210, 135, 243, 129, 48, 218, 170, 171, 28, 168, 56, 52, 208, 116, 240, 169, 224, 243, 60, 124, 82, 47, 159, 112, 16, 55, 138, 144 } });

            migrationBuilder.CreateIndex(
                name: "IX_HeroRole_RoleId",
                table: "HeroRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroRole");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 156, 224, 143, 246, 218, 172, 128, 54, 105, 235, 170, 161, 175, 231, 12, 81, 98, 92, 209, 113, 254, 86, 64, 205, 152, 254, 237, 56, 112, 170, 202, 254, 152, 0, 198, 0, 214, 144, 211, 195, 98, 13, 109, 46, 233, 105, 207, 237, 14, 220, 17, 12, 179, 95, 49, 18, 247, 192, 27, 46, 76, 58, 183, 235 }, new byte[] { 96, 196, 88, 233, 164, 194, 31, 32, 155, 210, 194, 70, 174, 231, 19, 241, 207, 198, 233, 186, 83, 112, 28, 56, 215, 167, 78, 201, 86, 127, 126, 216, 138, 126, 16, 71, 106, 87, 19, 111, 228, 219, 124, 119, 121, 5, 185, 121, 70, 231, 201, 130, 175, 148, 231, 42, 210, 181, 79, 156, 250, 255, 144, 137, 166, 189, 190, 46, 254, 19, 174, 106, 12, 175, 7, 72, 253, 35, 3, 138, 66, 182, 26, 105, 217, 71, 194, 175, 126, 121, 119, 154, 157, 104, 193, 166, 245, 66, 97, 113, 45, 250, 81, 215, 70, 206, 7, 111, 252, 130, 232, 20, 246, 224, 2, 159, 143, 88, 120, 114, 197, 77, 34, 75, 60, 248, 105, 33 } });
        }
    }
}
