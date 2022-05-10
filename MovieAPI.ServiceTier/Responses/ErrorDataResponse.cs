using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.ServiceTier.Responses
{
    public class ErrorDataResponse<T> : DataResponse<T>
    {
        public ErrorDataResponse(T data,string message) : base(success:false,message:message)
        {
            Data = data;
        }

        public ErrorDataResponse(T data) : base(success:false)
        {
            Data = data;
        }
    }
}
