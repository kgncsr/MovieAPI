using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.ServiceTier.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expirition  { get; set; }
        public string  UserName  { get; set; }
        public int  UserId  { get; set; }
    }
}
