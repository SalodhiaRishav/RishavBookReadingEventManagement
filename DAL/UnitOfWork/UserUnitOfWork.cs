using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Interfaces;
using DAL.Repositories;

namespace DAL.UnitOfWork
{
    public class UserUnitOfWork : UnitOfWork
    {
        private DBcontext DBcontext;
        public UserRepository UserRepository { get; set; }
        public UserUnitOfWork(DBcontext dBcontext) : base(dBcontext)
        {
            DBcontext = dBcontext;
            UserRepository = new UserRepository(dBcontext);
        }
  
    }
}
