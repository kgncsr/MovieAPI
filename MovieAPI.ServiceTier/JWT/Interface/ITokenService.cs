using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.ServiceTier.JWT.Interface
{
    public interface ITokenService
    {
        public AccessToken CreateToken(int userId, string name,string email);
    }
}
