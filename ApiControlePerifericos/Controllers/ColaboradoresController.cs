
using ApiControlePerifericos.Interfaces;
using ApiControlePerifericos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiControlePerifericos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ColaboradoresController : ControllerBase
    {
        private readonly IUnityOfWork _uof;
        private readonly ILogger<ColaboradoresController> _logger;

        public ColaboradoresController(IUnityOfWork uof, ILogger<ColaboradoresController> logger)
        {
            _uof = uof;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var colaboradores = _uof.ColaboradorRepository.GetAll();
            return Ok(colaboradores);
        }

        [HttpGet("{id}", Name = "ObterColaborador")]
        public IActionResult Get(int id)
        {
            var colaborador = _uof.ColaboradorRepository.Get(c => c.ColaboradorId == id);
            if (colaborador == null)
            {
                _logger.LogWarning($"Colaborador com ID {id} não encontrado.");
                return NotFound($"Colaborador com ID {id} não encontrado.");
            }
            return Ok(colaborador);
        }

        [HttpPost]
        public IActionResult Post(Colaborador colaborador)
        {
            if (colaborador == null)
            {
                _logger.LogWarning($"Dados do colaborador inválidos.");
                return BadRequest("Dados do colaborador inválidos.");
            }
            _uof.ColaboradorRepository.Create(colaborador);
            _uof.Commit();
            return CreatedAtRoute("ObterColaborador", new { id = colaborador.ColaboradorId }, colaborador);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Colaborador colaborador)
        {
            if (colaborador is null || id != colaborador.ColaboradorId)
            {
                _logger.LogWarning($"Dados do colaborador inválidos ou colaborador não encontrado.");
                return BadRequest("Dados do colaborador inválidos ou colaborador não encontrado.");
            }

            _uof.ColaboradorRepository.Update(colaborador);
            _uof.Commit();
            return Ok(colaborador);
        }

        [HttpDelete("{id:int}")]

        public IActionResult Delete(int id)
        {
            var colaborador = _uof.ColaboradorRepository.Get(c => c.ColaboradorId == id);
            if (colaborador is null)
            {
                _logger.LogWarning($"Colaborador com ID {id} não encontrado.");
                return NotFound($"Colaborador com ID {id} não encontrado.");
            }

            var colaboradorExcluido = _uof.ColaboradorRepository.Delete(colaborador);
            _uof.Commit();
            return Ok(colaboradorExcluido);
        }
    }
}
