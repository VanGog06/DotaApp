using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaApp.Data.Migrations
{
    public partial class CommentReviewColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Comments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "Comments",
                nullable: false,
                defaultValue: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 245, 143, 157, 194, 124, 5, 196, 92, 82, 12, 49, 125, 116, 122, 93, 196, 173, 155, 223, 184, 74, 213, 176, 57, 126, 192, 184, 114, 238, 125, 184, 27, 161, 19, 96, 93, 189, 192, 48, 85, 149, 236, 96, 132, 185, 160, 20, 71, 12, 68, 240, 60, 86, 54, 131, 228, 179, 163, 180, 63, 38, 116, 10, 69 }, new byte[] { 103, 26, 148, 69, 144, 80, 209, 196, 195, 68, 127, 41, 169, 30, 9, 158, 122, 122, 56, 115, 84, 66, 77, 54, 67, 85, 14, 203, 141, 217, 175, 82, 55, 185, 39, 226, 213, 196, 9, 84, 73, 126, 24, 151, 66, 73, 240, 200, 97, 19, 129, 197, 18, 103, 160, 106, 140, 160, 95, 70, 36, 183, 65, 34, 232, 85, 163, 30, 37, 43, 31, 117, 74, 10, 111, 18, 118, 81, 180, 38, 60, 246, 1, 178, 109, 147, 119, 63, 64, 0, 61, 108, 18, 49, 212, 65, 96, 75, 177, 116, 208, 164, 112, 254, 99, 185, 144, 101, 12, 14, 139, 59, 226, 89, 185, 174, 80, 247, 7, 167, 156, 39, 249, 59, 192, 158, 106, 80 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 97, 1, 22, 70, 8, 142, 212, 211, 169, 113, 162, 32, 11, 215, 54, 174, 184, 30, 42, 85, 112, 244, 225, 65, 251, 165, 108, 118, 59, 214, 174, 221, 167, 142, 93, 115, 36, 239, 14, 199, 6, 21, 187, 174, 179, 231, 184, 142, 114, 124, 149, 91, 170, 69, 34, 21, 83, 76, 129, 204, 195, 174, 145, 151 }, new byte[] { 123, 133, 80, 97, 41, 218, 218, 243, 99, 169, 147, 77, 249, 109, 38, 129, 89, 159, 89, 127, 207, 47, 123, 32, 17, 143, 32, 174, 54, 200, 64, 225, 148, 144, 143, 43, 229, 104, 173, 175, 125, 170, 8, 103, 250, 237, 3, 247, 68, 135, 40, 7, 38, 199, 113, 23, 94, 153, 35, 158, 52, 107, 204, 44, 176, 179, 239, 155, 246, 12, 95, 11, 116, 41, 96, 157, 83, 94, 154, 199, 244, 149, 109, 179, 98, 223, 174, 85, 12, 160, 152, 19, 222, 99, 231, 87, 62, 95, 112, 220, 122, 137, 118, 1, 170, 45, 233, 5, 112, 215, 34, 92, 22, 177, 90, 183, 183, 181, 251, 82, 207, 170, 169, 146, 15, 13, 155, 63 } });
        }
    }
}
