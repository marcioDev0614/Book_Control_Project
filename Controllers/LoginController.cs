using ControleDeCadastroDeLivros.Helper;
using ControleDeCadastroDeLivros.Models;
using ControleDeCadastroDeLivros.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeCadastroDeLivros.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        private readonly ISessao _sessao;
        public LoginController(IUsuarioRepositorio usuarioRepositorio,

            ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;

        }
        public IActionResult Index()
        {
            // Se o usuário estiver logado, redirecionar para a home

            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {

                UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);
                if (ModelState.IsValid)
                {
                    if(usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha do usuário é inválida, tente novamente";
                    }
                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente.";
                }

                return View("Index");

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");

            }
        }
        
    }
}
