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
        private DBcontext DBcontext;
       public BookReadingEventRepository(DBcontext dBcontext):base(dBcontext)
        {
            DBcontext = dBcontext;
        }

        public List<object> GetInvitedEvents(string email)
        {
            var events = DBcontext.BookReadingEvents.ToList();
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
