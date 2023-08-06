using ControleDeCadastroDeLivros.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeCadastroDeLivros.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<LivroModel> Livros { get; set; }

        public DbSet<UsuarioModel> Usuarios { get; set; }

    }
}
