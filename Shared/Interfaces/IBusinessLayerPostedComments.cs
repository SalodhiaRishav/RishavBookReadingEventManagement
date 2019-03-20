using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO;

namespace Shared.Interfaces
{
    public interface IBusinessLayerPostedComments
    {
        void PostComment(PostedCommentDTO postedCommentDTO);
        List<PostedCommentDTO> GetComments(int eventID);
    }
}
