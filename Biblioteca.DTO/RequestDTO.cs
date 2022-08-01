using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.DTO
{
    public class RequestDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public IDictionary Exceptions { get; set; }

        public RequestDTO GenerateBasicResponse(bool tipo)
        {
            var request = new RequestDTO()
            {
                Success = tipo
            };
            return request;
        }
    }
}
