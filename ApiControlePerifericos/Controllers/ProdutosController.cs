

using ApiControlePerifericos.Interfaces;
using ApiControlePerifericos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiControlePerifericos.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class ProdutosController: ControllerBase
    {
        private readonly IUnityOfWork _uof;
        private readonly ILogger<ColaboradoresController> _logger;

        public ProdutosController(IUnityOfWork uof, ILogger<ColaboradoresController> logger)
        {
            _uof = uof;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var produtos = _uof.ProdutoRepository.GetAll();
            return Ok(produtos);
        }

        [HttpGet("{id}", Name = "ObterProduto")]
        public IActionResult Get(int id)
        {
            var produto = _uof.ProdutoRepository.Get(p => p.ProdutoId == id);
            if (produto == null)
            {
                _logger.LogWarning($"Dados do produto inválidos.");
                return BadRequest("Dados do produto inválidos.");
            }
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Post(Produto produto)
        {
            if (produto == null)
            {
                _logger.LogWarning($"Dados do produto inválidos.");
                return BadRequest("Dados do produto inválidos.");
            }
            _uof.ProdutoRepository.Create(produto);
            _uof.Commit();
            return CreatedAtRoute("ObterProduto", new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Produto produto)
        {
            if (produto is null || produto.ProdutoId != id)
            {
                _logger.LogWarning($"Dados do produto inválidos ou produto não encontrado.");
                return BadRequest("Dados do produto inválidos ou produto não encontrado.");
            }
            _uof.ProdutoRepository.Update(produto);
            _uof.Commit();
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = _uof.ProdutoRepository.Get(p => p.ProdutoId == id);
            if (produto is null)
            {
                _logger.LogWarning($"Produto com ID {id} não encontrado.");
                return NotFound($"Produto com ID {id} não encontrado.");
            }

            var produtoExcluido = _uof.ProdutoRepository.Delete(produto);
            _uof.Commit();
            return Ok(produtoExcluido);
        }
    }
}
