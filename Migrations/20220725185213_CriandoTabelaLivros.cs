using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace API_Livros.Migrations
{
    public partial class CriandoTabelaLivros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeLivro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeAutor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumPaginas = table.Column<int>(type: "int", nullable: false),
                    StatusLivro = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livros");
        }
    }
}
