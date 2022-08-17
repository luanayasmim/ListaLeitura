using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Livros.Migrations
{
    public partial class tblUsersOut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersOut",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameUserOut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginUserOut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailUserOut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordUserOut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifyEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersOut", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersOut");
        }
    }
}
