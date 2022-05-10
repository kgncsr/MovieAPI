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
        public DataResponse(bool success) : base(success)
        {

        }

        public DataResponse(bool success, string message) : base(success, message)
        {

        }

        public T Data { get; set; }
    }
}
