
using API_Livros.Models;
using CsvHelper.Configuration;

namespace API_Livros.Mappers
{
    public sealed class LivroMap : ClassMap<LivroModel>
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
        }
    }
}
