using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Hunter_FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_lookUpValues_lookUpValuesId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "lookUpValuesId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_lookUpValues_lookUpValuesId",
                table: "AspNetUsers",
                column: "lookUpValuesId",
                principalTable: "lookUpValues",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_lookUpValues_lookUpValuesId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "lookUpValuesId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_lookUpValues_lookUpValuesId",
                table: "AspNetUsers",
                column: "lookUpValuesId",
                principalTable: "lookUpValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
