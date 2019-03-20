using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.CustomException;
using Shared.Interfaces;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private Dbcontext DBcontext;
        public UnitOfWork()
        {
            DBcontext = new Dbcontext();
        }

        public DbContext DbContext { get { return DBcontext; } }

        public bool Commit()
        {
            try
            {
                int savedChanges = DbContext.SaveChanges();
            }
            catch(DataException)
            {
                throw new DataBaseUpdationException("Error while Updating Data In database");
              
            }

            return true;
        }
    }
}
