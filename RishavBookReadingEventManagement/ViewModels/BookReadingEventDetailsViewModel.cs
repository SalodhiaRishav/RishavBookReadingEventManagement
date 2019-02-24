using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RishavBookReadingEventManagement.ViewModels
{
    public class BookReadingEventDetailsViewModel
    {
        public int ID { get; set; }
        public string BookTitle { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public string StartTime { get; set; }

        public Shared.CustomDataTypes.EventType Type { get; set; }

        public int? Duration { get; set; }

        public string Description { get; set; }

        public string OtherDetails { get; set; }

        public string InvitedEmails { get; set; }

        public string Comments { get; set; }

        public int UserID { get; set; }

    }
}