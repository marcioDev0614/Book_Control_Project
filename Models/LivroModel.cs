using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeCadastroDeLivros.Models
{
    public class LivroModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o titulo do livro.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Digite o nome do escritor.")]
        public string Escritor { get; set; }

        [Required(ErrorMessage = "Digite uma breve descrição do livro.")]

        public string Descricao { get; set; }
    }
}
