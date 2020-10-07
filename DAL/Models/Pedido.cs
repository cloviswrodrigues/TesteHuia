using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Pedido
    {
        public int id { get; set; }
        public Cadastro cliente { get; set; }
        public Cadastro vendedor { get; set; }
        public double valortotal { get; set; }
        public DateTime dtcompra { get; set; }
        public List<PedidoItem> pedidoItens { get; set; }
    }
}
