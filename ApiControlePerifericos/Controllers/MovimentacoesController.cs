using ApiControlePerifericos.Interfaces;
using ApiControlePerifericos.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiControlePerifericos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimentacoesController : ControllerBase
    {
        private readonly IUnityOfWork _uof;
        private readonly ILogger<ColaboradoresController> _logger;

        public MovimentacoesController(IUnityOfWork uof, ILogger<ColaboradoresController> logger)
        {
            _uof = uof;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var movimentacoes = _uof.MovimentacaoRepository.GetAll();
            return Ok(movimentacoes);
        }

        [HttpGet("{id}", Name = "ObterMovimentacao")]
        public IActionResult Get(int id)
        {
            var movimentacao = _uof.MovimentacaoRepository.Get(m => m.MovimentacaoId == id);
            if (movimentacao == null)
            {
                _logger.LogWarning($"Dados da movimentação inválidos.");
                return BadRequest("Dados da movimentação inválidos.");
            }
            return Ok(movimentacao);
        }

        [HttpPost]
        public IActionResult Post(Movimentacao movimentacao)
        {
            if (movimentacao == null)
            {
                _logger.LogWarning($"Dados da movimentação inválidos.");
                return BadRequest("Dados da movimentação inválidos.");
            }
            _uof.MovimentacaoRepository.Create(movimentacao);
            _uof.Commit();
            return CreatedAtRoute("ObterMovimentacao", new { id = movimentacao.MovimentacaoId }, movimentacao);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Movimentacao movimentacao)
        {
            if (movimentacao is null || movimentacao.MovimentacaoId != id)
            {
                _logger.LogWarning($"Dados da movimentação inválidos ou ID da movimentação não corresponde ao ID fornecido.");
                return BadRequest("Dados da movimentação inválidos ou ID da movimentação não corresponde ao ID fornecido.");
            }
            _uof.MovimentacaoRepository.Update(movimentacao);
            _uof.Commit();
            return Ok(movimentacao);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var movimentacao = _uof.MovimentacaoRepository.Get(m => m.MovimentacaoId == id);
            if (movimentacao is null)
            {
                _logger.LogWarning($"Movimentação com ID {id} não encontrada.");
                return NotFound($"Movimentação com ID {id} não encontrada.");
            }
            _uof.MovimentacaoRepository.Delete(movimentacao);
            _uof.Commit();
            return Ok(movimentacao);

        }
    }
}
