using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shared.DTO;

namespace RishavBookReadingEventManagement.ViewModels
{
    public class HomePageModel
    {
        public List<BookReadingEventDTO> FutureEvents= new List<BookReadingEventDTO>();
        public List<BookReadingEventDTO> PastEvents = new List<BookReadingEventDTO>();
    }
}