using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domains;
using Shared.Interfaces;

namespace DAL.Repositories
{
   public class PostedCommentRepository : Repository<PostedComment>,IPostedCommentRepository
    {
        private DBcontext DBcontext;
        public PostedCommentRepository(DBcontext dBcontext) : base(dBcontext)
        {
            DBcontext = dBcontext;
        }
    }
}
