using ControleDeCadastroDeLivros.Data;
using ControleDeCadastroDeLivros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeCadastroDeLivros.Repositorio
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private readonly BancoContext _bancoContext;
        public LivroRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public LivroModel ListarPorId(int id)
        {
            return _bancoContext.Livros.FirstOrDefault(x => x.Id == id);
        }

        public List<LivroModel> BuscarTodos()
        {
            return _bancoContext.Livros.ToList();
        }
        public LivroModel Adicionar(LivroModel livro)
        {
            // gravar no banco de dados
            _bancoContext.Livros.Add(livro);
            _bancoContext.SaveChanges();
            return livro;
        }

        public LivroModel Atualizar(LivroModel livro)
        {
            LivroModel livroDB = ListarPorId(livro.Id);
            if (livroDB == null) throw new SystemException("Houve um erro na atualização do livro");

            livroDB.Titulo = livro.Titulo;
            livroDB.Escritor = livro.Escritor;
            livroDB.Descricao = livro.Descricao;

            _bancoContext.Livros.Update(livroDB);
            _bancoContext.SaveChanges();
            return livroDB;
        }

        public bool Apagar(int id)
        {
            LivroModel livroDB = ListarPorId(id);
            if (livroDB == null) throw new SystemException("Houve um erro na deleção do livro!");

            _bancoContext.Livros.Remove(livroDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
