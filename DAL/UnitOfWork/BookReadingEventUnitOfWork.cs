using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using Shared.Interfaces;

namespace DAL.UnitOfWork
{
   public class BookReadingEventUnitOfWork : UnitOfWork
    {
        private DBcontext DBcontext;
        public BookReadingEventRepository BookReadingEventRepository;
        public BookReadingEventUnitOfWork(DBcontext dBcontext):base(dBcontext)
        {
            DBcontext = dBcontext;
            BookReadingEventRepository = new BookReadingEventRepository(DBcontext);
        }

       
    }
}
