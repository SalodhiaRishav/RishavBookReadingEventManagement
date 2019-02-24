using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domains;
using Shared.Interfaces;

namespace DAL.Repositories
{
   public class InvitedToEventRepository : Repository<InvitedToEvent>,IInvitedToEventsRepository
    {
        private DBcontext DBcontext;
        public InvitedToEventRepository(DBcontext dBcontext) : base(dBcontext)
        {
            DBcontext = dBcontext;
        }
    }
}
