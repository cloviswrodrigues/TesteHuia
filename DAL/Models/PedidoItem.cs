using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class PedidoItem
    {
        public int id { get; set; }
        public int pedidoid { get; set; }
        public int produtoid { get; set; }
        public Produto produto { get; set; }
        public int quantidade { get; set; }
    }
}
