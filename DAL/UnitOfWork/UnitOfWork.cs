using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.CustomException;
using Shared.Interfaces;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DBcontext DBcontext;
        public UnitOfWork(DBcontext dBcontext)
        {
            DBcontext = dBcontext;
        }
        public bool Commit()
        {
            try
            {
                int savedChanges = DBcontext.SaveChanges();
            }
            catch(DataException)
            {
                throw new DataBaseUpdationException("Error while Updating Data In database");
              
            }

            return true;
        }
    }
}
