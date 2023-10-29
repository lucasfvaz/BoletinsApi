using FirstAPI.Models;
using FirstAPI.Services;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletimFurtoVeiculoController : ControllerBase
    {
        private readonly IBoletimFurtoVeiculoService _boletimService;

        public BoletimFurtoVeiculoController(IBoletimFurtoVeiculoService boletimService)
        {
            _boletimService = boletimService;

        }        

        [HttpPost]
        public ActionResult<BoletimFurtoVeiculo> CreateBoletim([FromBody] BoletimFurtoVeiculoDTO boletimDTO)
        {
            var boletim = _boletimService.CreateBoletim(boletimDTO);
            if (boletim == null)
            {
                return BadRequest("Falha ao criar o boletim de furto.");
            }

            return CreatedAtAction(nameof(GetBoletim), new { id = boletim.Identificador }, boletim);
        }

        [HttpPut("{id}")]
        public ActionResult<BoletimFurtoVeiculo> UpdateBoletim(int id, [FromBody] BoletimFurtoVeiculoDTO boletimDTO)
        {
            var boletim = _boletimService.UpdateBoletim(id, boletimDTO);
            if (boletim == null)
            {
                return NotFound("Boletim de furto não encontrado.");
            }

            return Ok(boletim);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBoletim(int id)
        {
            _boletimService.DeleteBoletim(id);
            return NoContent();
        }

        [HttpGet]
        public ActionResult<IEnumerable<BoletimFurtoVeiculo>> GetBoletinsByFilter([FromQuery] string? cidade, [FromQuery] string? periodo)
        {
            var boletins = _boletimService.GetBoletinsByFilter(cidade, periodo);
            return Ok(boletins);
        }

        [HttpGet("veiculos")]
        public ActionResult<IEnumerable<Veiculo>> GetVeiculosByFilter([FromQuery] string? placa, [FromQuery] string? cor, [FromQuery] string? tipoVeiculo)
        {
            var veiculos = _boletimService.GetVeiculosByFilter(placa, cor, tipoVeiculo);

            if (veiculos.Any())
            {
                return Ok(veiculos);
            }
            else
            {
                return NotFound("Nenhum veículo encontrado com os filtros fornecidos.");
            }
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<BoletimFurtoVeiculo>> GetAll()
        {
            var boletins = _boletimService.GetAll();
            return Ok(boletins);
        }


        [HttpGet("{id}")]
        public ActionResult<BoletimFurtoVeiculo> GetBoletim(int id)
        {
            var boletim = _boletimService.GetBoletim(id);
            if (boletim == null)
            {
                return NotFound("Boletim de furto não encontrado.");
            }

            return Ok(boletim);
        }
    }
}
