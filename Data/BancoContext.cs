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
    }
}
