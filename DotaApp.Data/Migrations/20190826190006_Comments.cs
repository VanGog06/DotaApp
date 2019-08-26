using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaApp.Data.Migrations
{
    public partial class Comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommentMessage = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Items_ItemId",
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
                values: new object[] { new byte[] { 97, 1, 22, 70, 8, 142, 212, 211, 169, 113, 162, 32, 11, 215, 54, 174, 184, 30, 42, 85, 112, 244, 225, 65, 251, 165, 108, 118, 59, 214, 174, 221, 167, 142, 93, 115, 36, 239, 14, 199, 6, 21, 187, 174, 179, 231, 184, 142, 114, 124, 149, 91, 170, 69, 34, 21, 83, 76, 129, 204, 195, 174, 145, 151 }, new byte[] { 123, 133, 80, 97, 41, 218, 218, 243, 99, 169, 147, 77, 249, 109, 38, 129, 89, 159, 89, 127, 207, 47, 123, 32, 17, 143, 32, 174, 54, 200, 64, 225, 148, 144, 143, 43, 229, 104, 173, 175, 125, 170, 8, 103, 250, 237, 3, 247, 68, 135, 40, 7, 38, 199, 113, 23, 94, 153, 35, 158, 52, 107, 204, 44, 176, 179, 239, 155, 246, 12, 95, 11, 116, 41, 96, 157, 83, 94, 154, 199, 244, 149, 109, 179, 98, 223, 174, 85, 12, 160, 152, 19, 222, 99, 231, 87, 62, 95, 112, 220, 122, 137, 118, 1, 170, 45, 233, 5, 112, 215, 34, 92, 22, 177, 90, 183, 183, 181, 251, 82, 207, 170, 169, 146, 15, 13, 155, 63 } });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ItemId",
                table: "Comments",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 75, 61, 69, 243, 147, 10, 30, 24, 139, 36, 167, 235, 226, 115, 241, 140, 253, 186, 249, 253, 16, 64, 114, 229, 181, 255, 207, 160, 77, 29, 239, 165, 175, 152, 104, 243, 145, 218, 118, 215, 221, 52, 158, 165, 35, 5, 58, 99, 215, 231, 52, 33, 147, 128, 146, 202, 192, 75, 248, 87, 102, 112, 176, 54 }, new byte[] { 222, 68, 123, 108, 166, 14, 77, 210, 122, 77, 118, 27, 235, 216, 126, 62, 140, 145, 71, 197, 131, 68, 44, 135, 203, 158, 115, 43, 41, 11, 36, 19, 74, 171, 133, 146, 26, 96, 211, 190, 136, 222, 105, 145, 156, 227, 144, 100, 19, 223, 174, 13, 171, 157, 3, 208, 101, 111, 253, 42, 162, 19, 77, 211, 19, 138, 244, 41, 63, 127, 251, 223, 175, 27, 31, 33, 230, 165, 139, 206, 152, 202, 164, 233, 92, 241, 119, 11, 219, 163, 176, 34, 59, 240, 206, 168, 7, 216, 32, 21, 10, 6, 41, 229, 103, 42, 15, 0, 3, 245, 46, 6, 94, 135, 22, 185, 206, 137, 238, 232, 92, 215, 116, 253, 204, 217, 231, 179 } });
        }
    }
}
