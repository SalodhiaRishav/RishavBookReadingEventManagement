using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domains;
using DAL;
using System.Data.Entity;
using Shared.Interfaces;

namespace DAL.Repositories
{
    public class BookReadingEventRepository : Repository<BookReadingEvent>,IBookReadingEventRepositories
    {
   
       public BookReadingEventRepository(IBookReadingEventUnitOfWork bookReadingEventUnitOfWork):base(bookReadingEventUnitOfWork)
        {
          
        }

        public List<object> GetInvitedEvents(string email)
        {
            var events = DbSet.ToList();
            List<object> invitedEventList = new List<object>();
            foreach(BookReadingEvent evt in events)
            {
                if(evt.InvitedEmails!=null)
                {
                    if(evt.InvitedEmails.Split(',').ToList().Find(ema=>ema==email)!=null)
                    {
                        invitedEventList.Add(evt);
                    }
                }
            }
            return invitedEventList;
        }
    }
}
