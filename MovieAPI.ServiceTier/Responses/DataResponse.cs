using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.ServiceTier.Responses
{
    public class DataResponse<T> : Response
    {
        public DataResponse()
        {

        }
        public DataResponse(bool success,T data) : base(success)
        {
            Data = data;
        }

        public DataResponse(bool success, string message, T data) : base(success, message)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
