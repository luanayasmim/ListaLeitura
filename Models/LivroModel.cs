using System;
using System.ComponentModel.DataAnnotations;

namespace API_Livros.Models
{
    public class LivroModel
    {
        public int Id { get; set; }

        //Utilizando o DataAnnotations para fazer validações
        [Required(ErrorMessage ="Informe o título!")]
        public string NomeLivro { get; set; }

        [Required(ErrorMessage = "Informe o Autor(a)!")]
        public string NomeAutor { get; set; }


        [Required(ErrorMessage = "Informe a data de lançamento!")]
        public DateTime DataLancamento { get; set; }


        [Required(ErrorMessage = "Informe o número de páginas!")]
        public int NumPaginas { get; set; }

        public bool StatusLivro { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
