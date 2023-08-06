using ControleDeCadastroDeLivros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeCadastroDeLivros.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioModel usuarioModel);

        void RemoverSessaoUsuario();


        UsuarioModel BuscarSessaoDoUsuario();

        
    }
}
