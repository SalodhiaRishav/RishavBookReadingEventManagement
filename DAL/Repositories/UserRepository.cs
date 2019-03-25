using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domains;
using DAL.RepositoryInterfaces;
using Shared.Interfaces;


namespace DAL.Repositories
{
    public class UserRepository : Repository<User>,IUserRepositories
    {
        public UserRepository(IUserUnitOfWork userUnitOfWork) : base(userUnitOfWork)
        {
            
        }


    }
}
