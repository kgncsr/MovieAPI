using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAPI.DataTier.Context;
using MovieAPI.DataTier.Interfaces;
using MovieAPI.ModelTier;

namespace MovieAPI.DataTier.Concrete
{
    public class UserRepository : CrudRepository<User>,IUserRepository 
    {
        public UserRepository(MovieContext movieContext) : base(movieContext)
        {
        }
    }
}
