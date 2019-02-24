using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domains;
using Shared.Interfaces;


namespace DAL.Repositories
{
    public class UserRepository : Repository<User>,IUserRepositories
    {
        readonly DBcontext DBcontext;
        public UserRepository(DBcontext dBcontext) : base(dBcontext)
        {
            DBcontext = dBcontext;
        }


    }
}
