using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Domains
{
    public class InvitedToEvent : Domain
    {
        public int? UserID { get; set; }
        public int? BookReadingEventID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [ForeignKey("BookReadingEventID")]
        public virtual BookReadingEvent BookReadingEvent { get; set;}
    }
}
