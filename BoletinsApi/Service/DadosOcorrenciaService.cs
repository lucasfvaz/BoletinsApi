using ApiBoletins.Models;
using FirstAPI.Models;
using System.Globalization;

namespace ApiBoletins.Service
{
    public class DadosOcorrenciaService
    {
        List<DadosOcorrenciaDTO> dadosOcorrenciaList;
        List<BoletimFurtoVeiculo> _boletinsFurto = new List<BoletimFurtoVeiculo>();
        private int _nextBoletimId = 1;

        public List<BoletimFurtoVeiculo> populaDados(string filePath)
        {
            dadosOcorrenciaList = new List<DadosOcorrenciaDTO>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string header = reader.ReadLine(); // Ignora a linha de cabeçalho
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split('\t'); // Use '\t' como delimitador

                        DadosOcorrenciaDTO ocorrencia = new DadosOcorrenciaDTO
                        {
                            ANO_BO = ParseInt(values[0]),
                            NUM_BO = ParseInt(values[1]),
                            NUMERO_BOLETIM = values[2],
                            BO_INICIADO = ParseDateTime(values[3]),
                            BO_EMITIDO = ParseDateTime(values[4]),
                            DATAOCORRENCIA = ParseDateTime(values[5]),
                            HORAOCORRENCIA = values[6],
                            PERIDOOCORRENCIA = values[7],
                            DATACOMUNICACAO = ParseDateTime(values[8]),
                            DATAELABORACAO = ParseDateTime(values[9]),
                            BO_AUTORIA = values[10],
                            FLAGRANTE = values[11],
                            NUMERO_BOLETIM_PRINCIPAL = values[12],
                            LOGRADOURO = values[13],
                            NUMERO = values[14],
                            BAIRRO = values[15],
                            CIDADE = values[16],
                            UF = values[17],
                            LATITUDE = ParseDouble(values[18]),
                            LONGITUDE = ParseDouble(values[19]),
                            DESCRICAOLOCAL = values[20],
                            EXAME = values[21],
                            SOLUCAO = values[22],
                            DELEGACIA_NOME = values[23],
                            DELEGACIA_CIRCUNSCRICAO = values[24],
                            ESPECIE = values[25],
                            RUBRICA = values[26],
                            DESDOBRAMENTO = values[27],
                            STATUS = values[28],
                            TIPOPESSOA = values[29],
                            VITIMAFATAL = values[30],
                            NATURALIDADE = values[31],
                            NACIONALIDADE = values[32],
                            SEXO = values[33],
                            DATANASCIMENTO = ParseDateTime(values[34]),
                            IDADE = ParseInt(values[35]),
                            ESTADOCIVIL = values[36],
                            PROFISSAO = values[37],
                            GRAUINSTRUCAO = values[38],
                            CORCUTIS = values[39],
                            NATUREZAVINCULADA = values[40],
                            TIPOVINCULO = values[41],
                            RELACIONAMENTO = values[42],
                            PARENTESCO = values[43],
                            PLACA_VEICULO = values[44],
                            UF_VEICULO = values[45],
                            CIDADE_VEICULO = values[46],
                            DESCR_COR_VEICULO = values[47],
                            DESCR_MARCA_VEICULO = values[48],
                            ANO_FABRICACAO = ParseInt(values[49]),
                            ANO_MODELO = ParseInt(values[50]),
                            DESCR_TIPO_VEICULO = values[51],
                            QUANT_CELULAR = ParseInt(values[52]),
                            MARCA_CELULAR = values[53]
                        };

                        dadosOcorrenciaList.Add(ocorrencia);
                    }
                    foreach (var ocorrencia in dadosOcorrenciaList)
                    {
                        BoletimFurtoVeiculo boletimFurtoVeiculo = new BoletimFurtoVeiculo();
                        boletimFurtoVeiculo.Identificador = _nextBoletimId++;
                        boletimFurtoVeiculo.DataOcorrencia = ocorrencia.DATAOCORRENCIA;
                        boletimFurtoVeiculo.PeriodoOcorrencia = ocorrencia.PERIDOOCORRENCIA;
                        boletimFurtoVeiculo.LocalOcorrencia = ocorrencia.DESCRICAOLOCAL;
                        boletimFurtoVeiculo.VeiculoFurtado = new FirstAPI.Veiculo
                        {
                            Id = boletimFurtoVeiculo.Identificador,
                            TipoVeiculo = ocorrencia.DESCR_TIPO_VEICULO,
                            Marca = ocorrencia.DESCR_MARCA_VEICULO,
                            Modelo = ocorrencia.DESCR_MARCA_VEICULO,
                            AnoFabricacao = ocorrencia.ANO_FABRICACAO,
                            Cor = ocorrencia.DESCR_COR_VEICULO,
                            Emplacamento = new FirstAPI.Emplacamento
                            {
                                Placa = ocorrencia.PLACA_VEICULO,
                                Estado = ocorrencia.UF,
                                Cidade = ocorrencia.CIDADE_VEICULO
                            }
                        };
                        _boletinsFurto.Add(boletimFurtoVeiculo);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao ler o arquivo: " + e.Message);
            }
            return _boletinsFurto;
        }

        // Função auxiliar para fazer a conversão segura de inteiros
        static int ParseInt(string value)
        {
            int result;
            if (int.TryParse(value, out result))
            {
                return result;
            }
            return 0; // Valor padrão se a conversão falhar
        }

        // Função auxiliar para fazer a conversão segura de datas
        static DateTime ParseDateTime(string value)
        {
            DateTime result;
            if (DateTime.TryParse(value, out result))
            {
                return result;
            }
            return DateTime.MinValue; // Valor padrão se a conversão falhar
        }

        // Função auxiliar para fazer a conversão segura de números de ponto flutuante
        static double ParseDouble(string value)
        {
            double result;
            if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out result))
            {
                return result;
            }
            return 0.0; // Valor padrão se a conversão falhar
        }
    }
}
