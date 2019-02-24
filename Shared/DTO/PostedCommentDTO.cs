using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
   public class PostedCommentDTO
    {
        public string EmailID { get; set; }
        public int BookReadingEventID { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
