using ControleDeCadastroDeLivros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeCadastroDeLivros.Repositorio
{
    public interface ILivroRepositorio
    {
        LivroModel ListarPorId(int id);
        List<LivroModel> BuscarTodos();
        LivroModel Adicionar(LivroModel livro);

        LivroModel Atualizar(LivroModel livro);

        bool Apagar(int id);
      
    }
}
