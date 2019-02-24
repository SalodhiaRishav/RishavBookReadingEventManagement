using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class BookReadingEventDTO
    {
        public int ID { get; set; }

        public string BookTitle { get; set; }

        public DateTime Date { get; set; }
    
        public string Location { get; set; }
      
        public string StartTime { get; set; }

        public CustomDataTypes.EventType Type { get; set; }

        public int? Duration { get; set; }

        public string Description { get; set; }

        public string OtherDetails { get; set; }

        public string InvitedEmails { get; set; }

        public int UserID { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
