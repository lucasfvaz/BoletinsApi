namespace FirstAPI.Models
{
    public class BoletimFurtoVeiculo
    {
        public int Identificador { get; set; }
        public DateTime? DataOcorrencia { get; set; }
        public string? PeriodoOcorrencia { get; set; }
        public string? LocalOcorrencia { get; set; }
        public Veiculo VeiculoFurtado { get; set; }
        public List<Parte>? Partes { get; set; }
    }
}
