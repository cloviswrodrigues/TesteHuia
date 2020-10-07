using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Cadastro
    {
        public int id { get; set; }
        public string cpf { get; set; }
        public string nome { get; set; }
        public DateTime dtnascimento { get; set; }
    }
}
