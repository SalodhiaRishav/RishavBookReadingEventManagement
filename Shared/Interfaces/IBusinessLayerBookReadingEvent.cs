using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO;

namespace Shared.Interfaces
{
    public interface IBusinessLayerBookReadingEvent
    {
        void CreateNewBookEvent(BookReadingEventDTO bookReadingEventDTO);
        BookReadingEventDTO GetBookReadingEventDetails(int id);
        List<BookReadingEventDTO> GetMyEvents(int userID);
        void EditBookReadingEvent(BookReadingEventDTO bookReadingEventDTO);
        List<BookReadingEventDTO> InvitedEvents(string email);
        List<BookReadingEventDTO> GetAllEvents();

    }
}
