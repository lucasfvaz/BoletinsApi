namespace ApiBoletins.Models
{
    public class DadosOcorrenciaDTO
    {
        public int ANO_BO { get; set; }
        public int NUM_BO { get; set; }
        public string NUMERO_BOLETIM { get; set; }
        public DateTime BO_INICIADO { get; set; }
        public DateTime BO_EMITIDO { get; set; }
        public DateTime DATAOCORRENCIA { get; set; }
        public string HORAOCORRENCIA { get; set; }
        public string PERIDOOCORRENCIA { get; set; }
        public DateTime DATACOMUNICACAO { get; set; }
        public DateTime DATAELABORACAO { get; set; }
        public string BO_AUTORIA { get; set; }
        public string FLAGRANTE { get; set; }
        public string NUMERO_BOLETIM_PRINCIPAL { get; set; }
        public string LOGRADOURO { get; set; }
        public string NUMERO { get; set; }
        public string BAIRRO { get; set; }
        public string CIDADE { get; set; }
        public string UF { get; set; }
        public double LATITUDE { get; set; }
        public double LONGITUDE { get; set; }
        public string DESCRICAOLOCAL { get; set; }
        public string EXAME { get; set; }
        public string SOLUCAO { get; set; }
        public string DELEGACIA_NOME { get; set; }
        public string DELEGACIA_CIRCUNSCRICAO { get; set; }
        public string ESPECIE { get; set; }
        public string RUBRICA { get; set; }
        public string DESDOBRAMENTO { get; set; }
        public string STATUS { get; set; }
        public string TIPOPESSOA { get; set; }
        public string VITIMAFATAL { get; set; }
        public string NATURALIDADE { get; set; }
        public string NACIONALIDADE { get; set; }
        public string SEXO { get; set; }
        public DateTime DATANASCIMENTO { get; set; }
        public int IDADE { get; set; }
        public string ESTADOCIVIL { get; set; }
        public string PROFISSAO { get; set; }
        public string GRAUINSTRUCAO { get; set; }
        public string CORCUTIS { get; set; }
        public string NATUREZAVINCULADA { get; set; }
        public string TIPOVINCULO { get; set; }
        public string RELACIONAMENTO { get; set; }
        public string PARENTESCO { get; set; }
        public string PLACA_VEICULO { get; set; }
        public string UF_VEICULO { get; set; }
        public string CIDADE_VEICULO { get; set; }
        public string DESCR_COR_VEICULO { get; set; }
        public string DESCR_MARCA_VEICULO { get; set; }
        public int ANO_FABRICACAO { get; set; }
        public int ANO_MODELO { get; set; }
        public string DESCR_TIPO_VEICULO { get; set; }
        public int QUANT_CELULAR { get; set; }
        public string MARCA_CELULAR { get; set; }
    }
}
