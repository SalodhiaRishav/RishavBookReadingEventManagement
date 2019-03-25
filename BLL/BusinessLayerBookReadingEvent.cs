using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Domains;
using DAL.Repositories;
using DAL.RepositoryInterfaces;
using DAL.UnitOfWork;
using Shared.DTO;
using Shared.Interfaces;

namespace BLL
{
    public class BusinessLayerBookReadingEvent : IBusinessLayerBookReadingEvent
    {
        private IBookReadingEventRepositories BookReadingEventRepository;
   
      
        public BusinessLayerBookReadingEvent(IBookReadingEventRepositories bookReadingEventRepositories)
        {          
        
            BookReadingEventRepository = bookReadingEventRepositories;
      
        }

        public void CreateNewBookEvent(BookReadingEventDTO bookReadingEventDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookReadingEventDTO, BookReadingEvent>());
            var mapper = config.CreateMapper();
            BookReadingEvent bookReadingEvent = mapper.Map<BookReadingEventDTO, BookReadingEvent>(bookReadingEventDTO);
            bookReadingEvent.ModifiedOn = DateTime.Now;
            bookReadingEvent.CreatedOn = DateTime.Now;
            BookReadingEventRepository.Add(bookReadingEvent);
            
        }

        public void EditBookReadingEvent(BookReadingEventDTO bookReadingEventDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookReadingEventDTO, BookReadingEvent>());
            var mapper = config.CreateMapper();
            BookReadingEvent bookReadingEvent = mapper.Map<BookReadingEventDTO, BookReadingEvent>(bookReadingEventDTO);
            bookReadingEvent.ModifiedOn = DateTime.Now;
            BookReadingEventRepository.Update(bookReadingEvent);
       
        }

        public List<BookReadingEventDTO> GetAllEvents()
        {
            List<BookReadingEvent> eventList =BookReadingEventRepository.List;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookReadingEvent, BookReadingEventDTO>());
            var mapper = config.CreateMapper();
            List<BookReadingEventDTO> eventListDTO = mapper.Map<List<BookReadingEvent>, List<BookReadingEventDTO>>(eventList);
            return eventListDTO;
        }

        public BookReadingEventDTO GetBookReadingEventDetails(int id)
        {
            BookReadingEvent bookReadingEvent = BookReadingEventRepository.FindById(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookReadingEvent, BookReadingEventDTO>());
            var mapper = config.CreateMapper();
            BookReadingEventDTO bookReadingEventDTO = mapper.Map<BookReadingEvent, BookReadingEventDTO>(bookReadingEvent);
            return bookReadingEventDTO;
        }

        public List<BookReadingEventDTO> GetMyEvents(int userID)
        {
            List<BookReadingEvent> myEvents = BookReadingEventRepository.Find(bookevent => bookevent.UserID == userID).ToList();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookReadingEvent, BookReadingEventDTO>());
            var mapper = config.CreateMapper();
            List<BookReadingEventDTO> myEventsList = mapper.Map<List<BookReadingEvent>, List<BookReadingEventDTO>>(myEvents);
            return myEventsList;
        }

        public List<BookReadingEventDTO> InvitedEvents(string email)
        {
            List<BookReadingEvent> list = new List<BookReadingEvent>();
            List<object> templist = BookReadingEventRepository.GetInvitedEvents(email);
            foreach (object evt in templist)
            {
                list.Add((BookReadingEvent)evt);
            }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookReadingEvent, BookReadingEventDTO>());
            var mapper = config.CreateMapper();
            List<BookReadingEventDTO> invitedEventList = mapper.Map<List<BookReadingEvent>, List<BookReadingEventDTO>>(list);
            return invitedEventList;
        }
    }
}
