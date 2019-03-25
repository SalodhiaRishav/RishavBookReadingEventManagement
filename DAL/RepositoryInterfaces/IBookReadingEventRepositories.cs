using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Interfaces;
using DAL.Domains;
namespace DAL.RepositoryInterfaces
{ 
    public interface IBookReadingEventRepositories : IRepositories<BookReadingEvent>
    {
        List<object> GetInvitedEvents(string email);
      
    }
}
