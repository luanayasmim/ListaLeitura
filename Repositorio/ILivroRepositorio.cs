using API_Livros.Models;
using System.Collections.Generic;

namespace API_Livros.Repositorio
{
    public interface ILivroRepositorio
    {
        List<LivroModel> BuscarTodos(int userId);
        LivroModel ListarPorId(int id);
        LivroModel Adicionar(LivroModel livro);
        LivroModel Atualizar(LivroModel livro);

        bool Apagar(int id);

    }
}
