namespace CopaHAS.DTOs
{
    public class JogoDTO
    {
        public int IdJogo { get; set; }
        public DateTime DataHora { get; set; }
        public string Estadio { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string SelecaoMandante { get; set; } = null!;
        public int GolsMandante { get; set; }
        public int GolsDecisaoPenaltisMandante { get; set; }
        public string TecnicoMandante { get; set; } = string.Empty;
        public string SelecaoVisitante { get; set; } = null!;
        public int GolsVisitante { get; set; }
        public int GolsDecisaoPenaltisVisitante { get; set; }
        public string TecnicoVisitante { get; set; } = string.Empty;
    }
}
