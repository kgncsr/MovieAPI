using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.ServiceTier.Responses
{
    public class ErrorResponse : Response
    {

        public ErrorResponse():base(success:false)
        {
            
        }

        public ErrorResponse(string message):base(success:false,message:message)
        {
            
        }
    }
}
