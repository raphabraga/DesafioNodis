using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Service;
using API;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _productService;
        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController(ILogger<ProdutoController> logger, ProdutoService service)
        {
            _logger = logger;
            _productService = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarProduto([FromQuery] Guid id)
        {
            var produto = await _productService.BuscarProdutoPorId(id);
            return Ok(produto);
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodosProdutos()
        {
            var produtos = await _productService.BuscarTodos();
            return Ok(produtos);
        }

        [HttpPost]
        public async Task<IActionResult> CriarProduto([FromBody] Produto produto)
        {
            //var produto = await _productService.CriarProduto();
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task DeletarProduto(Guid id)
        {
            var produto = await _productService.DeletarProduto(id);
            return NoContent();
        }
    }
}
