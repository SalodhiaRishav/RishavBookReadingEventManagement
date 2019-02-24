using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using DAL.Domains;
using DAL.UnitOfWork;
using Shared.DTO;
using Shared.CustomException;

namespace BLL
{
    public class BusinessLogics
    {
        private DBcontext DBcontext;
        BookReadingEventUnitOfWork BookReadingEventUnitOfWork;
        UserUnitOfWork UserUnitOfWork;
        PostCommentUnitOfWork PostCommentUnitOfWork;
        public BusinessLogics()
        {
            DBcontext = new DBcontext();
            PostCommentUnitOfWork = new PostCommentUnitOfWork(DBcontext);
            BookReadingEventUnitOfWork = new BookReadingEventUnitOfWork(DBcontext);
            UserUnitOfWork = new UserUnitOfWork(DBcontext);

        }
        public List<BookReadingEventDTO> GetAllEvents()
        {
            List<BookReadingEvent> eventList = BookReadingEventUnitOfWork.BookReadingEventRepository.List;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookReadingEvent, BookReadingEventDTO>());
            var mapper = config.CreateMapper();
            List<BookReadingEventDTO> eventListDTO = mapper.Map<List<BookReadingEvent>, List<BookReadingEventDTO>>(eventList);
            return eventListDTO;
        }
    
        public LoginedUserDTO SignUp(SignUpUserDTO loginUser)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SignUpUserDTO,User>());
            var mapper = config.CreateMapper();
            User user= mapper.Map<SignUpUserDTO,User>(loginUser);
            user.CreatedOn = DateTime.Now;
            user.ModifiedOn = DateTime.Now;
            UserUnitOfWork.UserRepository.Add(user);
            bool isCommited = false;
           
                isCommited = UserUnitOfWork.Commit();
            
          
            if (isCommited)
            {
                User returnuser=UserUnitOfWork.UserRepository.Find(tempuser => (tempuser.Email == user.Email && tempuser.Password == user.Password)).ToList().First();
                var config2 = new MapperConfiguration(cfg => cfg.CreateMap<User, LoginedUserDTO>());
                var mapper2 = config2.CreateMapper();
                LoginedUserDTO logineduser = mapper2.Map<User, LoginedUserDTO>(returnuser);
                return logineduser;
            }

            return null;
        }

        public LoginedUserDTO LoginUser(LoginUserDTO loginUserDTO)
        {
            var list = UserUnitOfWork.UserRepository.Find(tempuser => (tempuser.Email == loginUserDTO.Email && tempuser.Password == loginUserDTO.Password)).ToList();
            if(list.Count!=0)
            {
                User user = list.First();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<User, LoginedUserDTO>());
                var mapper = config.CreateMapper();
                LoginedUserDTO logineduser = mapper.Map<User, LoginedUserDTO>(user);
                return logineduser;
            }
            return null;
        }

        public void CreateNewBookEvent(BookReadingEventDTO bookReadingEventDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookReadingEventDTO, BookReadingEvent>());
            var mapper = config.CreateMapper();
            BookReadingEvent bookReadingEvent = mapper.Map<BookReadingEventDTO, BookReadingEvent>(bookReadingEventDTO);
            bookReadingEvent.ModifiedOn = DateTime.Now;
            bookReadingEvent.CreatedOn = DateTime.Now;
            BookReadingEventUnitOfWork.BookReadingEventRepository.Add(bookReadingEvent);
            BookReadingEventUnitOfWork.Commit();
        }

        public BookReadingEventDTO GetBookReadingEventDetails(int id)
        {
            BookReadingEvent bookReadingEvent = BookReadingEventUnitOfWork.BookReadingEventRepository.FindById(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookReadingEvent,BookReadingEventDTO > ());
            var mapper = config.CreateMapper();
            BookReadingEventDTO bookReadingEventDTO = mapper.Map<BookReadingEvent,BookReadingEventDTO>(bookReadingEvent);
            return bookReadingEventDTO;
        }

        public List<BookReadingEventDTO> GetMyEvents(int userID)
        {
            List<BookReadingEvent> myEvents = BookReadingEventUnitOfWork.BookReadingEventRepository.Find(bookevent => bookevent.UserID == userID).ToList();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookReadingEvent, BookReadingEventDTO>());
            var mapper = config.CreateMapper();
            List<BookReadingEventDTO> myEventsList = mapper.Map<List<BookReadingEvent>,List<BookReadingEventDTO>>(myEvents);
            return myEventsList;
        }

        public void EditBookReadingEvent(BookReadingEventDTO bookReadingEventDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookReadingEventDTO, BookReadingEvent>());
            var mapper = config.CreateMapper();
            BookReadingEvent bookReadingEvent = mapper.Map<BookReadingEventDTO, BookReadingEvent>(bookReadingEventDTO);
            bookReadingEvent.ModifiedOn = DateTime.Now;
            BookReadingEventUnitOfWork.BookReadingEventRepository.Update(bookReadingEvent);
            BookReadingEventUnitOfWork.Commit();
        }

        public List<BookReadingEventDTO> InvitedEvents(string email)
        {
            List<BookReadingEvent> list = new List<BookReadingEvent>();
            List<object> templist = BookReadingEventUnitOfWork.BookReadingEventRepository.GetInvitedEvents(email);
            foreach(object evt in templist)
            {
                list.Add((BookReadingEvent)evt);
            }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookReadingEvent,BookReadingEventDTO>());
            var mapper = config.CreateMapper();
            List<BookReadingEventDTO> invitedEventList = mapper.Map<List<BookReadingEvent>,List<BookReadingEventDTO>>(list);
            return invitedEventList;
        }

        public void PostComment(PostedCommentDTO postedCommentDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PostedCommentDTO, PostedComment>());
            var mapper = config.CreateMapper();
            PostedComment postedComment = mapper.Map<PostedCommentDTO, PostedComment>(postedCommentDTO);
            postedComment.CreatedOn = DateTime.Now;
            postedComment.ModifiedOn = DateTime.Now;
            PostCommentUnitOfWork.PostedCommentRepository.Add(postedComment);
            PostCommentUnitOfWork.Commit();
        }

        public List<PostedCommentDTO> GetComments(int eventID)
        {
           List<PostedComment> postedComments= PostCommentUnitOfWork.PostedCommentRepository.Find(comment => comment.BookReadingEventID == eventID).ToList();
           var config = new MapperConfiguration(cfg => cfg.CreateMap<PostedComment,PostedCommentDTO>());
            var mapper = config.CreateMapper();
            List<PostedCommentDTO> comments = mapper.Map<List<PostedComment>,List<PostedCommentDTO>>(postedComments);

            return comments;
        }

        public bool CheckEmailExistence(string email)
        {
           int count= UserUnitOfWork.UserRepository.Find(user => user.Email==email).ToList().Count();
            if(count==0)
            {
                return true;
            }
            return false;
        }

    }
}
