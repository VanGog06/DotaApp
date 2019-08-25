using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaApp.Data.Migrations
{
    public partial class Items : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Cost = table.Column<int>(nullable: false),
                    Lore = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(nullable: true),
                    Header = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Footer = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemAttributes_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 75, 61, 69, 243, 147, 10, 30, 24, 139, 36, 167, 235, 226, 115, 241, 140, 253, 186, 249, 253, 16, 64, 114, 229, 181, 255, 207, 160, 77, 29, 239, 165, 175, 152, 104, 243, 145, 218, 118, 215, 221, 52, 158, 165, 35, 5, 58, 99, 215, 231, 52, 33, 147, 128, 146, 202, 192, 75, 248, 87, 102, 112, 176, 54 }, new byte[] { 222, 68, 123, 108, 166, 14, 77, 210, 122, 77, 118, 27, 235, 216, 126, 62, 140, 145, 71, 197, 131, 68, 44, 135, 203, 158, 115, 43, 41, 11, 36, 19, 74, 171, 133, 146, 26, 96, 211, 190, 136, 222, 105, 145, 156, 227, 144, 100, 19, 223, 174, 13, 171, 157, 3, 208, 101, 111, 253, 42, 162, 19, 77, 211, 19, 138, 244, 41, 63, 127, 251, 223, 175, 27, 31, 33, 230, 165, 139, 206, 152, 202, 164, 233, 92, 241, 119, 11, 219, 163, 176, 34, 59, 240, 206, 168, 7, 216, 32, 21, 10, 6, 41, 229, 103, 42, 15, 0, 3, 245, 46, 6, 94, 135, 22, 185, 206, 137, 238, 232, 92, 215, 116, 253, 204, 217, 231, 179 } });

            migrationBuilder.CreateIndex(
                name: "IX_ItemAttributes_ItemId",
                table: "ItemAttributes",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemAttributes");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 80, 233, 91, 86, 204, 203, 110, 253, 107, 175, 29, 63, 143, 125, 217, 68, 212, 227, 101, 231, 90, 182, 93, 191, 42, 53, 44, 195, 178, 45, 141, 112, 133, 78, 80, 235, 215, 241, 166, 103, 103, 135, 218, 143, 59, 45, 30, 197, 173, 106, 137, 118, 84, 220, 217, 251, 104, 107, 17, 91, 222, 35, 32, 217 }, new byte[] { 231, 179, 46, 141, 52, 55, 202, 93, 140, 212, 98, 141, 12, 49, 30, 8, 108, 195, 97, 37, 41, 175, 118, 174, 243, 116, 212, 147, 132, 57, 214, 59, 97, 223, 189, 111, 40, 70, 244, 16, 83, 164, 12, 40, 169, 249, 76, 101, 247, 223, 80, 54, 185, 155, 211, 126, 251, 61, 227, 187, 237, 120, 240, 243, 60, 127, 77, 164, 148, 238, 71, 217, 6, 188, 184, 215, 15, 167, 12, 95, 51, 56, 196, 45, 178, 30, 113, 90, 34, 114, 20, 253, 136, 190, 108, 62, 90, 58, 158, 244, 19, 69, 29, 163, 24, 17, 211, 196, 208, 201, 63, 203, 205, 140, 217, 85, 154, 121, 232, 36, 4, 22, 249, 217, 233, 155, 255, 184 } });
        }
    }
}
