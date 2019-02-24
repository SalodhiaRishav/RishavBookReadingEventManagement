using System;
using Shared.CustomDataTypes;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Domains
{
   public class BookReadingEvent : Domain
    {
        
        [Required]
        public string BookTitle { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }

        
        public string StartTime { get; set; }

        [Required]
        public EventType Type { get; set; }

        public int? Duration { get; set; }

        public string Description { get; set; }

        public string OtherDetails { get; set; }

        public string InvitedEmails { get; set; }

        [Required]
        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
        public virtual ICollection<PostedComment> PostedComments { get; set; }

    }
}
