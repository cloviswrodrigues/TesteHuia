using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class Produto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cor { get; set; }
        public string descricao { get; set; }
        public double valor { get; set; }
        public List<Lote> lote { get; set; }
    }
}