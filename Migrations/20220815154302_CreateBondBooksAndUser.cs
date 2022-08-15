using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Livros.Migrations
{
    public partial class CreateBondBooksAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProfileUser",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Livros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Livros_UserId",
                table: "Livros",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Users_UserId",
                table: "Livros",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserModelId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Users_UserId",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Livros_UserId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Livros");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileUser",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
