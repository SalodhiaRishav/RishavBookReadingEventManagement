using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;

namespace DAL.UnitOfWork
{
    public class PostCommentUnitOfWork : UnitOfWork
    {
        private DBcontext DBcontext;
        public PostedCommentRepository PostedCommentRepository;
        public PostCommentUnitOfWork(DBcontext dBcontext) : base(dBcontext)
        {
            DBcontext = dBcontext;
            PostedCommentRepository = new PostedCommentRepository(DBcontext);
        }
    }
}
