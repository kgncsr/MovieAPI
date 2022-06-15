using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAPI.Entities.Cammon;

namespace MovieAPI.ModelTier
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public  string Token { get; set; }
        public DateTime? TokenExpireDate { get; set; }

    }
}
