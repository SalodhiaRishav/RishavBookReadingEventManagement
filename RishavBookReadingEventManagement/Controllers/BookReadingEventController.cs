using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RishavBookReadingEventManagement.ViewModels;
using BLL;
using Shared.DTO;
using AutoMapper;
using Shared.CustomDataTypes;
using Shared.CustomException;
using Shared.Interfaces;
using DAL.UnitOfWork;

namespace RishavBookReadingEventManagement.Controllers
{
    public class BookReadingEventController : Controller
    {
        IBusinessLayerBookReadingEvent BusinessLayerBookReadingEvent;
        IBusinessLayerPostedComments BusinessLayerPostedComments;
       
        public BookReadingEventController(IBusinessLayerBookReadingEvent businessLayerBookReadingEvent,IBusinessLayerPostedComments businessLayerPostedComments)
        {
          
            BusinessLayerBookReadingEvent = businessLayerBookReadingEvent;           
            BusinessLayerPostedComments = businessLayerPostedComments;

        }
        // GET: BookReadingEvent
       
        public ActionResult Index()
        {
            List<BookReadingEventDTO> eventListDTO = BusinessLayerBookReadingEvent.GetAllEvents();
            HomePageModel homePageModel = new HomePageModel();
            if (Session["userID"] == null)
            {
                foreach (BookReadingEventDTO evt in eventListDTO)
                {
                    if (evt.Type == EventType.Public)
                    {
                        if (evt.Date < DateTime.Now)
                        {
                            homePageModel.PastEvents.Add(evt);
                        }
                        else
                        {
                            homePageModel.FutureEvents.Add(evt);
                        }
                    }
                }
            }
            else
            {
                foreach (BookReadingEventDTO evt in eventListDTO)
                {
                    
                        if (evt.Date < DateTime.Now)
                        {
                            homePageModel.PastEvents.Add(evt);
                        }
                        else
                        {
                            homePageModel.FutureEvents.Add(evt);
                        }
                    
                }
            }

            return View(homePageModel);
        }

        public ActionResult CreateNewEvent()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewEvent([Bind(Include = "BookTitle, Date, Location,StartTime,Type,Duration,Description,OtherDetails,InvitedEmails")]CreateNewEventViewModel createNewEventViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateNewEventViewModel, BookReadingEventDTO>());
                    var mapper = config.CreateMapper();
                    BookReadingEventDTO bookReadingEventDTO = mapper.Map<CreateNewEventViewModel, BookReadingEventDTO>(createNewEventViewModel);
                    bookReadingEventDTO.UserID = int.Parse(Session["userID"].ToString());
                    BusinessLayerBookReadingEvent.CreateNewBookEvent(bookReadingEventDTO);
                    return RedirectToAction("Index");
                }
            }
            catch(FormatException)
            {
                return Content("<h2>Input string is not a sequence of digits.<h2>");
            }
            catch (DataBaseUpdationException exception)
            {
                return Content(exception.Message);
            }
            return View();
        }


        public ActionResult GetBookReadingEventDetails(int id)
        {
            BookReadingEventDTO bookReadingEventDTO = BusinessLayerBookReadingEvent.GetBookReadingEventDetails(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookReadingEventDTO,BookReadingEventDetailsViewModel>());
            var mapper = config.CreateMapper();
            BookReadingEventDetailsViewModel bookReadingEventDetailsViewModel = mapper.Map<BookReadingEventDTO, BookReadingEventDetailsViewModel>(bookReadingEventDTO);
            return View("GetBookReadingEventDetails", bookReadingEventDetailsViewModel);
        }

        [Authorize]
        public ActionResult GetMyEvents()
        {
            try
            {
                int userID = int.Parse(Session["userID"].ToString());
                List<BookReadingEventDTO> myEventListDTO = BusinessLayerBookReadingEvent.GetMyEvents(userID);
                var config = new MapperConfiguration(cfg => cfg.CreateMap<BookReadingEventDTO, MyBookEventsViewModels>());
                var mapper = config.CreateMapper();
                List<MyBookEventsViewModels> myBookEvents = mapper.Map<List<BookReadingEventDTO>, List<MyBookEventsViewModels>>(myEventListDTO);
                myBookEvents.Reverse();
                return View("GetMyEvents", myBookEvents);
            }
           catch(FormatException)
            {

                return Content("<h1>Input string is not a sequence of digits.<h1>");
            }
            
           
        }

        [Authorize]
        public ActionResult EditBookReadingEvent(int id)
        {
            BookReadingEventDTO bookReadingEventDTO = BusinessLayerBookReadingEvent.GetBookReadingEventDetails(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookReadingEventDTO, EditBookReadingEventViewModel>());
            var mapper = config.CreateMapper();
            EditBookReadingEventViewModel editBookEvent = mapper.Map<BookReadingEventDTO, EditBookReadingEventViewModel>(bookReadingEventDTO);
            return View(editBookEvent);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBookReadingEvent([Bind(Include = "ID,BookTitle, Date, Location,StartTime,Type,Duration,Description,OtherDetails,InvitedEmails,CreatedOn,UserID")]EditBookReadingEventViewModel editBookReadingEventViewModel)
        {    try
            {
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<EditBookReadingEventViewModel, BookReadingEventDTO>());
                    var mapper = config.CreateMapper();
                    BookReadingEventDTO bookReadingEventDTO = mapper.Map<EditBookReadingEventViewModel, BookReadingEventDTO>(editBookReadingEventViewModel);
                    //   bookReadingEventDTO.UserID = int.Parse(Session["userID"].ToString());
                    BusinessLayerBookReadingEvent.EditBookReadingEvent(bookReadingEventDTO);
                    if(Session["emailID"].ToString()=="rishav@admin.com")
                    {
                        return RedirectToAction("AdminHome");
                    }
                    return RedirectToAction("GetMyEvents");

                }
            }
            catch (DataBaseUpdationException exception)
            {
                return Content(exception.Message);
            }
            return View();
        }

        [Authorize]
        public ActionResult GetInvitedEvents()
        {
            string email = Session["emailID"].ToString();
            List<BookReadingEventDTO> list = BusinessLayerBookReadingEvent.InvitedEvents(email);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookReadingEventDTO, InvitedEventViewModels>());
            var mapper = config.CreateMapper();
            List<InvitedEventViewModels> invitedEventList= mapper.Map<List<BookReadingEventDTO>, List<InvitedEventViewModels>>(list);

            return View(invitedEventList);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment([Bind(Include ="ID,Comments")]BookReadingEventDetailsViewModel bookReadingEventDetailsViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    PostedCommentDTO postedCommentDTO = new PostedCommentDTO();
                    postedCommentDTO.BookReadingEventID = bookReadingEventDetailsViewModel.ID;
                    postedCommentDTO.Comments = bookReadingEventDetailsViewModel.Comments;
                    postedCommentDTO.EmailID = Session["emailID"].ToString();
                    BusinessLayerPostedComments.PostComment(postedCommentDTO);
                    return RedirectToAction("GetBookReadingEventDetails", new { id = bookReadingEventDetailsViewModel.ID });
                }
            }
            catch (DataBaseUpdationException exception)
            {
                return Content(exception.Message);
            }
            return View();
        }

        [ChildActionOnly]
        public ActionResult Comments(int eventID)
        {
            List<PostedCommentDTO> postedCommentDTOs = BusinessLayerPostedComments.GetComments(eventID);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PostedCommentDTO,PostedCommentViewModel>());
            var mapper = config.CreateMapper();
            List<PostedCommentViewModel> comments= mapper.Map<List<PostedCommentDTO>,List<PostedCommentViewModel>>(postedCommentDTOs);
            return PartialView(comments);

        }

        [Authorize]
        public ActionResult AdminHome()
        {
            List<BookReadingEventDTO> eventListDTO = BusinessLayerBookReadingEvent.GetAllEvents();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookReadingEventDTO, AdminHomeViewModel>());
            var mapper = config.CreateMapper();
            List<AdminHomeViewModel> adminHomeViewModels = mapper.Map<List<BookReadingEventDTO>, List<AdminHomeViewModel>>(eventListDTO);
            return View(adminHomeViewModels);
        }
    }
}