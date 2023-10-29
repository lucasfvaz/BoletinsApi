using System;
using System.Collections.Generic;

namespace FirstAPI.Models
{
    public class BoletimFurtoVeiculoDTO
    {
        public DateTime DataOcorrencia { get; set; }
        public string PeriodoOcorrencia { get; set; }
        public string LocalOcorrencia { get; set; }
        public Veiculo VeiculoFurtado { get; set; }
        public List<ParteDTO> Partes { get; set; }
    }
}
