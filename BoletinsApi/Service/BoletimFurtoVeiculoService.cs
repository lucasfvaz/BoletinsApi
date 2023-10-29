using ApiBoletins.Service;
using FirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstAPI.Services
{
    public interface IBoletimFurtoVeiculoService
    {
        BoletimFurtoVeiculo CreateBoletim(BoletimFurtoVeiculoDTO boletimDTO);
        BoletimFurtoVeiculo UpdateBoletim(int id, BoletimFurtoVeiculoDTO boletimDTO);
        void DeleteBoletim(int id);
        List<BoletimFurtoVeiculo> GetBoletinsByFilter(string cidade, string periodo);
        List<Veiculo> GetVeiculosByFilter(string placa, string cor, string tipoVeiculo);
        BoletimFurtoVeiculo GetBoletim(int id);
        List<BoletimFurtoVeiculo> GetAll();
    }

    public class BoletimFurtoVeiculoService : IBoletimFurtoVeiculoService
    {
        private List<BoletimFurtoVeiculo> _boletins;
        private readonly List<Veiculo> _veiculos;
        private int _nextBoletimId = 1;
        private string filepath = @"C:\Users\lucas\OneDrive\Área de Trabalho\furtos.csv";
        private DadosOcorrenciaService ocorrenciaService = new DadosOcorrenciaService();

        public BoletimFurtoVeiculoService()
        {
            _boletins = new List<BoletimFurtoVeiculo>();
            _boletins = ocorrenciaService.populaDados(filepath);
            _veiculos = new List<Veiculo>();
            _nextBoletimId = _boletins.Last().Identificador;
        }

        public BoletimFurtoVeiculo CreateBoletim(BoletimFurtoVeiculoDTO boletimDTO)
        {
            var boletim = new BoletimFurtoVeiculo
            {
                Identificador = _nextBoletimId++,
                DataOcorrencia = boletimDTO.DataOcorrencia,
                PeriodoOcorrencia = boletimDTO.PeriodoOcorrencia,
                LocalOcorrencia = boletimDTO.LocalOcorrencia,
                VeiculoFurtado = boletimDTO.VeiculoFurtado,                
            };

            boletim.VeiculoFurtado.Id = boletim.Identificador;

            boletim.Partes = boletimDTO.Partes.Select(p => new Parte
            {
                Nome = p.Nome,
                Email = p.Email,
                Telefones = p.Telefones.Select(t => new Telefone
                {
                    TipoEnvolvimento = t.TipoEnvolvimento,
                    Numero = t.Numero
                }).ToList()
            }).ToList();

            _boletins.Add(boletim);
            _veiculos.Add(boletim.VeiculoFurtado);
            return boletim;
        }

        public BoletimFurtoVeiculo UpdateBoletim(int id, BoletimFurtoVeiculoDTO boletimDTO)
        {
            var existingBoletim = _boletins.FirstOrDefault(b => b.Identificador == id);
            if (existingBoletim == null)
            {
                return null; // Boletim não encontrado
            }

            existingBoletim.DataOcorrencia = boletimDTO.DataOcorrencia;
            existingBoletim.PeriodoOcorrencia = boletimDTO.PeriodoOcorrencia;
            existingBoletim.LocalOcorrencia = boletimDTO.LocalOcorrencia;
            existingBoletim.VeiculoFurtado = boletimDTO.VeiculoFurtado;

            // Atualize as partes do boletim
            existingBoletim.Partes.Clear();
            existingBoletim.Partes.AddRange(boletimDTO.Partes.Select(p => new Parte
            {
                Nome = p.Nome,
                Email = p.Email,
                Telefones = p.Telefones.Select(t => new Telefone
                {
                    TipoEnvolvimento = t.TipoEnvolvimento,
                    Numero = t.Numero
                }).ToList()
            }));

            return existingBoletim;
        }

        public void DeleteBoletim(int id)
        {
            var boletim = _boletins.FirstOrDefault(b => b.Identificador == id);
            if (boletim != null)
            {
                _boletins.Remove(boletim);
            }
        }

        public List<BoletimFurtoVeiculo> GetBoletinsByFilter(string cidade = null, string periodo = null)
        {
            var boletins = _boletins.AsQueryable();

            if (!string.IsNullOrEmpty(cidade))
            {
                boletins = boletins.Where(b => b.VeiculoFurtado.Emplacamento.Cidade == cidade);
            }

            if (!string.IsNullOrEmpty(periodo))
            {
                boletins = boletins.Where(b => b.PeriodoOcorrencia == periodo);
            }

            return boletins.ToList();
        }


        public List<Veiculo> GetVeiculosByFilter(string placa, string cor, string tipoVeiculo)
        {
            var veiculos = _veiculos.AsQueryable();

            if(!string.IsNullOrEmpty(placa))
            {
                veiculos = veiculos.Where(v => v.Emplacamento.Placa == placa);
            }

            if (!string.IsNullOrEmpty(cor))
            {
                veiculos = veiculos.Where(v => v.Cor == cor);
            }

            if (!string.IsNullOrEmpty(tipoVeiculo))
            {
                veiculos = veiculos.Where(v => v.TipoVeiculo == tipoVeiculo);
            }

            return veiculos.ToList();
        }

        public BoletimFurtoVeiculo GetBoletim(int id)
        {
            return _boletins.FirstOrDefault(b => b.Identificador == id);
        }

        public List<BoletimFurtoVeiculo> GetAll()
        {
            return _boletins.ToList();
        }

    }
}
