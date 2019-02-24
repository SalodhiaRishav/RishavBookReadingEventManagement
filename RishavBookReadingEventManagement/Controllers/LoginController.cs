using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using RishavBookReadingEventManagement.ViewModels;
using Shared.DTO;
using BLL;
using Shared.CustomException;
using System.Web.Security;

namespace RishavBookReadingEventManagement.Controllers
{
    public class LoginController : Controller
    {
        public BusinessLogics BusinessLogics = new BusinessLogics();
        // GET: Login
        public ActionResult SignUp()
        {
            return View("SignUp");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include ="FirstName,LastName,Email,Password,ConfirmPassword")]SignUpViewModel signUpViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<SignUpViewModel, SignUpUserDTO>());
                    var mapper = config.CreateMapper();
                    SignUpUserDTO user = mapper.Map<SignUpViewModel, SignUpUserDTO>(signUpViewModel);
                    LoginedUserDTO loginedUser = BusinessLogics.SignUp(user);
                    if (loginedUser != null)
                    {
                        FormsAuthentication.SetAuthCookie(loginedUser.Email, false);

                        Session["userID"] = loginedUser.ID.ToString();
                        Session["emailID"] = loginedUser.Email;
                        return RedirectToAction("Index", "BookReadingEvent");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error while Registering in Database");
                        return View();
                    }


                }
            }
            catch(DataBaseUpdationException exception)
            {
                return Content(exception.Message);
            }
            
            return View();
        }

        public ActionResult LoginUser()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginUser(LoginUserViewModel loginUserViewModel)
        {
            
            if(ModelState.IsValid)
            {
                if (loginUserViewModel.Email == "rishav@admin.com" && loginUserViewModel.Password == "#Salodhia")
                {
                    Session["emailID"] = "rishav@admin.com";
                    FormsAuthentication.SetAuthCookie("rishav@admin.com", false);

                    return RedirectToAction("AdminHome", "BookReadingEvent");

                }
                var config = new MapperConfiguration(cfg => cfg.CreateMap<LoginUserViewModel,LoginUserDTO>());
                var mapper = config.CreateMapper();
                LoginUserDTO user = mapper.Map<LoginUserViewModel,LoginUserDTO>(loginUserViewModel);
                LoginedUserDTO loginedUser = BusinessLogics.LoginUser(user);
                if (loginedUser != null)
                {
                    FormsAuthentication.SetAuthCookie(loginedUser.Email, false);
                    Session["userID"] = loginedUser.ID.ToString();
                    Session["emailID"] = loginedUser.Email;
                    
                    return RedirectToAction("Index", "BookReadingEvent");
                }
                else
                {
                    ModelState.AddModelError("","You Entered Wrong Credential");
                    return View();
                }
            }

            return View();
        }

        public ActionResult LogOutUser()
        {
            FormsAuthentication.SignOut();
            Session["userID"] = null;
            Session["emailID"] = null;
            return RedirectToAction("Index", "BookReadingEvent");
        }


        [HttpPost]
        public JsonResult DoesUserNameExist(string email)
        {
            return Json(BusinessLogics.CheckEmailExistence(email));
        }
    }
}