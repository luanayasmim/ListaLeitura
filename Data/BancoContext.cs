using API_Livros.Mappers;
using API_Livros.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Livros.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<LivroModel> Livros { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LivroMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}

/*
 * Para adicionar a tabela no banco de dados e criar a migração com o Entity Framework deve utilizar os seguintes comandos no terminal:
 *      Add-Migration NomeMigração -Context NomeContexto
 *  
 *  Atualizar no Banco de Dados:
 *      Update-Database -Context NomeContexto
 */
