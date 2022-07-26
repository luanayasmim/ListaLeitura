using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
