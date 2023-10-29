namespace FirstAPI
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int? AnoFabricacao { get; set; }
        public string? Cor { get; set; }
        public string? TipoVeiculo { get; set; }
        public Emplacamento Emplacamento { get; set; }
    }
}
