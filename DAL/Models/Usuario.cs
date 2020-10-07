using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public int cadastroid { get; set; }
        public Cadastro cadastro { get; set; }        
    }
}
