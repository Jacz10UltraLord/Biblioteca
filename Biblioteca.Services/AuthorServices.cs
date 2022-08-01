using Biblioteca.DTO;
using Biblioteca.DTO.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Biblioteca.Services
{
    public class AuthorServices
    {
        private readonly string url = "https://localhost:44301/api/Authors";
        public async Task<RequestDTO> Create(Author author)
        { 
            var request = new RequestDTO().GenerateBasicResponse(false);
            try
            {
                var client = new HttpClient();

                var data = JsonConvert.SerializeObject(author);
                HttpContent content = new StringContent(data,System.Text.Encoding.UTF8,"application/json");
                var httpResponse = await client.PostAsync(url, content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    request = request.GenerateBasicResponse(true);
                }
                else { 
                    request.Message = httpResponse.RequestMessage.ToString();
                }
            }
            catch (Exception ex)
            {
                request.Exceptions = (System.Collections.IDictionary)ex;
            }
            return request;
        }

        public async Task<List<Author>> GetAuthors()
        {
            var authors = new List<Author>();
            try
            {
                var client = new HttpClient();
                string url = "https://localhost:44301/api/Authors";
                var json = await client.GetStringAsync(url);

                authors = JsonConvert.DeserializeObject<List<Author>>(json);
            }
            catch (Exception ex)
            {
            }
            return authors;
        }

    }
}
