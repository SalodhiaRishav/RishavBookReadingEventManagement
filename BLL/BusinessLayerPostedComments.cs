using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Domains;
using DAL.Repositories;
using Shared.DTO;
using Shared.Interfaces;

namespace BLL
{
    public class BusinessLayerPostedComments : IBusinessLayerPostedComments
    {
        private PostedCommentRepository PostedCommentRepository;
        private IPostedCommentUnitOfWork PostedCommentUnitOfWork;
        public BusinessLayerPostedComments(IPostedCommentUnitOfWork postedCommentUnitOfWork)
        {
            PostedCommentUnitOfWork = postedCommentUnitOfWork;
            PostedCommentRepository = new PostedCommentRepository(PostedCommentUnitOfWork);
        }
        public List<PostedCommentDTO> GetComments(int eventID)
        {
            List<PostedComment> postedComments = PostedCommentRepository.Find(comment => comment.BookReadingEventID == eventID).ToList();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PostedComment, PostedCommentDTO>());
            var mapper = config.CreateMapper();
            List<PostedCommentDTO> comments = mapper.Map<List<PostedComment>, List<PostedCommentDTO>>(postedComments);

            return comments;
        }

        public void PostComment(PostedCommentDTO postedCommentDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PostedCommentDTO, PostedComment>());
            var mapper = config.CreateMapper();
            PostedComment postedComment = mapper.Map<PostedCommentDTO, PostedComment>(postedCommentDTO);
            postedComment.CreatedOn = DateTime.Now;
            postedComment.ModifiedOn = DateTime.Now;
            PostedCommentRepository.Add(postedComment);
            PostedCommentUnitOfWork.Commit();
        }
    }
}
