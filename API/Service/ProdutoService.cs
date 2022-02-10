using System;
using System.Net.Http;
using System.Threading.Tasks;
using API.Service.Base;

namespace API.Service
{
    public class ProdutoService : HttpClientBase
    {
        public ProdutoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Produto> BuscarProdutoPorId(Guid produtoId)
        {
            var produto = await Get<Produto>(Environment.GetEnvironmentVariable("URI_SERVICE_PRODUTO") + "/Produto" + produtoId);
            //https://61ee984ed593d20017dbaf9c.mockapi.io/api/Produto
            return produto;
        }

        public async Task AlterarProduto(Guid produtoId)
        {
            await Task.Run(() =>
            {
                new NotImplementedException();
            });
        }

        public async Task BuscarTodos()
        {
            var produtos = await Get<Produto>(Environment.GetEnvironmentVariable("URI_SERVICE_PRODUTO") + "/Produto");
        }

        public async Task DeletarProduto(Guid produtoId)
        {
            await Task.Run(() =>
            {
                new NotImplementedException();
            });
        }
    }
}
