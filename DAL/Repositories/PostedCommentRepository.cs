using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domains;
using DAL.RepositoryInterfaces;
using Shared.Interfaces;

namespace DAL.Repositories
{
   public class PostedCommentRepository : Repository<PostedComment>,IPostedCommentRepository
    {
       
        public PostedCommentRepository(IPostedCommentUnitOfWork postedCommentUnitOfWork) : base(postedCommentUnitOfWork)
        {
           
        }
    }
}
