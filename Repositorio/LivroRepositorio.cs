using API_Livros.Data;
using API_Livros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Livros.Repositorio
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private readonly BancoContext _bancoContext;
        public LivroRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<LivroModel> BuscarTodos(int userId)
        {
            return _bancoContext.Livros.Where(x=>x.UserId == userId).ToList();
        }

        public LivroModel ListarPorId(int id)
        {
            return _bancoContext.Livros.FirstOrDefault(x=>x.Id==id);
        }

        public LivroModel Adicionar(LivroModel livro)
        {
            //Inserindo livro no banco
            livro.DataCadastro = DateTime.Now;
            _bancoContext.Livros.Add(livro);
            _bancoContext.SaveChanges();
            return livro;
        }

        public LivroModel Atualizar(LivroModel livro)
        {
            LivroModel livroDB = ListarPorId(livro.Id);

            if (livroDB == null) throw new SystemException("Houve um erro para atualizar o livro!");

            livroDB.NomeLivro = livro.NomeLivro;
            livroDB.NomeAutor = livro.NomeAutor;
            livroDB.DataLancamento = livro.DataLancamento;
            livroDB.NumPaginas = livro.NumPaginas;
            livroDB.StatusLivro = livro.StatusLivro;

            _bancoContext.Livros.Update(livroDB);
            _bancoContext.SaveChanges();
            return livroDB;
        }

        public bool Apagar(int id)
        {
            LivroModel livroDB = ListarPorId(id);

            if (livroDB == null) throw new SystemException("Houve um erro para excluir o livro!");

            _bancoContext.Livros.Remove(livroDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
