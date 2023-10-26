using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddedForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BookTypes",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "BookTypeId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookTypeId",
                table: "Books",
                column: "BookTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookTypes_BookTypeId",
                table: "Books",
                column: "BookTypeId",
                principalTable: "BookTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookTypes_BookTypeId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookTypeId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookTypeId",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BookTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);
        }
    }
}
