using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace API.Service.Base
{
    public abstract class HttpClientBase
    {
        protected HttpClient _httpClient;

        public HttpClientBase() { }

        protected async Task<T> Get<T>(string url)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

                HttpResponseMessage response = await _httpClient.SendAsync(request);

                var resposta = await RecuperaResposta(response);

                if (resposta != default(string))
                    return JsonConvert.DeserializeObject<T>(resposta);
                else
                    return default(T);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        protected async Task<T> Post<T>(string url, HttpContent conteudo)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = conteudo
                };

                HttpResponseMessage response = await _httpClient.SendAsync(request);

                string resposta = await RecuperaResposta(response);

                if (resposta != default(string))
                    return JsonConvert.DeserializeObject<T>(resposta);
                else
                    return default(T);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        protected async Task<T> Put<T>(string url, HttpContent conteudo)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, url)
                {
                    Content = conteudo
                };

                HttpResponseMessage response = await _httpClient.SendAsync(request);

                string resposta = await RecuperaResposta(response);

                if (resposta != default(string))
                    return JsonConvert.DeserializeObject<T>(resposta);
                else
                    return default(T);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        protected async Task<T> Delete<T>(string url, HttpContent conteudo)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, url)
                {
                    Content = conteudo
                };

                HttpResponseMessage response = await _httpClient.SendAsync(request);

                string resposta = await RecuperaResposta(response);

                if (resposta != default(string))
                    return JsonConvert.DeserializeObject<T>(resposta);
                else
                    return default(T);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        private async Task<string> RecuperaResposta(HttpResponseMessage response)
        {
            var statusCodesErro = new HashSet<HttpStatusCode>()
            {
                HttpStatusCode.BadRequest,
                HttpStatusCode.Unauthorized,
                HttpStatusCode.Forbidden,
                HttpStatusCode.BadGateway,
                HttpStatusCode.InternalServerError
            };

            if (response.StatusCode == HttpStatusCode.NoContent)
                return default(string);

            if (!statusCodesErro.Contains(response.StatusCode))
                return await response.Content.ReadAsStringAsync();
            else
                return default(string);
        }
    }
}