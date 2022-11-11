
using API_Livros.Models;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Livros.Mappers
{
    public sealed class LivroMap : ClassMap<LivroModel>, IEntityTypeConfiguration<LivroModel>
    {
        public LivroMap()
        {
            //Map(m => m.Id).Name("Id");
            Map(m => m.NomeLivro).Name("NomeLivro");
            Map(m => m.NomeAutor).Name("NomeAutor");
            Map(m => m.DataLancamento).Name("DataLancamento");
            Map(m => m.NumPaginas).Name("NumPaginas");
            Map(m => m.StatusLivro).Name("StatusLivro");
            Map(m => m.DataCadastro).Name("DataCadastro");
            Map(m => m.UserId).Name("UserId");
        }

        public void Configure(EntityTypeBuilder<LivroModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User);
        }
    }
}
