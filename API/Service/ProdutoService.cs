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

        public async Produto BuscarProdutoPorId(Guid produtoId)
        {
            var produto = await Post<string>(Environment.GetEnvironmentVariable("URI_SERVICE_PRODUTO"), null);
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
            await Task.Run(() =>
            {
                new NotImplementedException();
            });
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
