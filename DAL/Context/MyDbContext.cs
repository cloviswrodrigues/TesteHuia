using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Cadastro> Cadastros { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItens { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
    }
}
