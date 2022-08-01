using Biblioteca.DTO;
using Biblioteca.DTO.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Services
{
    public class BookServices
    {
        private readonly string url = "https://localhost:44301/api/Books";
        public async Task<RequestDTO> Create(Book book)
        {
            var request = new RequestDTO().GenerateBasicResponse(false);
            try
            {
                var client = new HttpClient();

                var data = JsonConvert.SerializeObject(book);
                HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var httpResponse = await client.PostAsync(url, content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    request = request.GenerateBasicResponse(true);
                }
                else
                {
                    request.Message = httpResponse.ReasonPhrase.ToString();
                    
                }
            }
            catch (Exception ex)
            {
                request.Exceptions = (System.Collections.IDictionary)ex;
            }
            return request;
        }
        public async Task<List<Book>> GetBooks()
        {
            var books = new List<Book>();
            try
            {
                var client = new HttpClient();
                string url = "https://localhost:44301/api/Books";
                var json = await client.GetStringAsync(url);

                books = JsonConvert.DeserializeObject<List<Book>>(json);
            }
            catch (Exception ex)
            {
            }
            return books;
        }
    }
}
