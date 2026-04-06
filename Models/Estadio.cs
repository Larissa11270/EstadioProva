using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaApi.Models
{
    public class Estadio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public int Capacidade { get; set; }

    }
}