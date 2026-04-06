using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaHAS.Models.Enuns;



namespace CopaHAS.Models
{
    public class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public int NumeroCamisa { get; set; }
        public string Posicao { get; set; } = string.Empty;
        public int SelecaoId { get; set; }
        public StatusJogador Status { get; set; }
    }
}