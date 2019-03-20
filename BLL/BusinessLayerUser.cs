using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Domains;
using DAL.Repositories;
using DAL.UnitOfWork;
using Shared.DTO;
using Shared.Interfaces;

namespace BLL
{
    public class BusinessLayerUser : IBusinessLayerUser
    {
        private IUserUnitOfWork UserUnitOfWork;
        private UserRepository UserRepository;
        public BusinessLayerUser(IUserUnitOfWork userUnitOfWork)
        {
            UserUnitOfWork = userUnitOfWork;
            UserRepository = new UserRepository(UserUnitOfWork);
        }
        public bool CheckEmailExistence(string email)
        {
            int count = UserRepository.Find(user => user.Email == email).ToList().Count();
            if (count == 0)
            {
                return true;
            }
            return false;
        }

        public LoginedUserDTO LoginUser(LoginUserDTO loginUserDTO)
        {
            var list = UserRepository.Find(tempuser => (tempuser.Email == loginUserDTO.Email && tempuser.Password == loginUserDTO.Password)).ToList();
            if (list.Count != 0)
            {
                User user = list.First();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<User, LoginedUserDTO>());
                var mapper = config.CreateMapper();
                LoginedUserDTO logineduser = mapper.Map<User, LoginedUserDTO>(user);
                return logineduser;
            }
            return null;
        }

        public LoginedUserDTO SignUp(SignUpUserDTO loginUser)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SignUpUserDTO, User>());
            var mapper = config.CreateMapper();
            User user = mapper.Map<SignUpUserDTO, User>(loginUser);
            user.CreatedOn = DateTime.Now;
            user.ModifiedOn = DateTime.Now;
            UserRepository.Add(user);
            bool isCommited = false;

            isCommited = UserUnitOfWork.Commit();


            if (isCommited)
            {
                User returnuser = UserRepository.Find(tempuser => (tempuser.Email == user.Email && tempuser.Password == user.Password)).ToList().First();
                var config2 = new MapperConfiguration(cfg => cfg.CreateMap<User, LoginedUserDTO>());
                var mapper2 = config2.CreateMapper();
                LoginedUserDTO logineduser = mapper2.Map<User, LoginedUserDTO>(returnuser);
                return logineduser;
            }

            return null;
        }
    }
}
