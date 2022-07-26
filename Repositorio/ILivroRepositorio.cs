using API_Livros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Livros.Repositorio
{
    public interface ILivroRepositorio
    {
        List<LivroModel> BuscarTodos();
        LivroModel ListarPorId(int id);
        LivroModel Adicionar(LivroModel livro);
        LivroModel Atualizar(LivroModel livro);

        bool Apagar(int id);

    }
}
