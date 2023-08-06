using ControleDeCadastroDeLivros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeCadastroDeLivros.Enums;

namespace ControleDeCadastroDeLivros.Repositorio
{
    public interface IUsuarioRepositorio
    {

        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);

        UsuarioModel Atualizar(UsuarioModel usuario);

        bool Apagar(int id);
      
    }
}
