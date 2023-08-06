using ControleDeCadastroDeLivros.Models;
using ControleDeCadastroDeLivros.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeCadastroDeLivros.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroRepositorio _livroRepositorio;
        public LivroController(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }
        public IActionResult Index()
        {
            List<LivroModel> livros = _livroRepositorio.BuscarTodos();
            return View(livros);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            LivroModel livro =  _livroRepositorio.ListarPorId(id);
            return View(livro);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            LivroModel livro = _livroRepositorio.ListarPorId(id);
            return View(livro);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
               bool apagado =  _livroRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Livro apagado com sucesso.";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu livro!";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu livro, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(LivroModel livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _livroRepositorio.Adicionar(livro);
                    TempData["MensagemSucesso"] = "Livro cadastrado com sucesso.";
                    return RedirectToAction("Index");
                }
                return View(livro);
            }
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu livro, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(LivroModel livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _livroRepositorio.Atualizar(livro);
                    TempData["MensagemSucesso"] = "Livro alterado com sucesso.";
                    return RedirectToAction("Index");
                }
                return View("Editar", livro);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu livro, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
         
        }
    }
}
