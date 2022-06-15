
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.ServiceTier.Responses
{
    public class SuccessResponse : Response
    {
        public SuccessResponse() : base(success:true)
        {
            
        }
        public SuccessResponse(string message) : base(success: true,message:message)
        {

        }
    }
}
