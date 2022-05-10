using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.ServiceTier.Responses
{
    public class SuccessDataResponse<T> : DataResponse<T>
    {
        public SuccessDataResponse(T data)  : base(success:true)
        {
            Data = data;
        }
        public SuccessDataResponse(T data,string message) : base(success: true,message:message)
        {
            Data = data;
        }
    }
}
