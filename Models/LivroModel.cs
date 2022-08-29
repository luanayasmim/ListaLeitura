using Postgrest.Attributes;
using Supabase;
using System;
using System.ComponentModel.DataAnnotations;

namespace API_Livros.Models
{
    [Table("Books")]
    public class LivroModel : SupabaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("book_name")]
        //Utilizando o DataAnnotations para fazer validações
        [Required(ErrorMessage ="Informe o título!")]
        public string NomeLivro { get; set; }

        [Column("author")]
        [Required(ErrorMessage = "Informe o Autor(a)!")]
        public string NomeAutor { get; set; }

        [Column("release_date")]
        [Required(ErrorMessage = "Informe a data de lançamento!")]
        public DateTime DataLancamento { get; set; }

        [Column("page_amount")]
        [Required(ErrorMessage = "Informe o número de páginas!")]
        public int NumPaginas { get; set; }

        [Column("status")]
        public bool StatusLivro { get; set; }

        [Column("register_date")]
        public DateTime DataCadastro { get; set; }

        [Column("user_id")]
        //Coluna que pega o id do usuário que cadastrar o livro
        public int? UserId { get; set; }

        public UserModel User { get; set; }
    }
}
