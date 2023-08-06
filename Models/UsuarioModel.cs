﻿using ControleDeCadastroDeLivros.Enums;
using ControleDeCadastroDeLivros.Helper;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeCadastroDeLivros.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o login do usuário.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do usuário.")]
        [EmailAddress(ErrorMessage = "O email informado não é válido!" )]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe o perfil do usuário.")]
        public PerfilEnum? Perfil { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuário.")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; } // simbolo de ? informa que o campo pode ser null.

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarRash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarRash();
        }
    }
}
