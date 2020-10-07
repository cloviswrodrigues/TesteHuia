using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Lote
    {
        public int id { get; set; }
        public DateTime dtfabricacao { get; set; }
        public int quantidade { get; set; }
        public int produtoid { get; set; }      
    }
}
