using AutoMapper;
using BusinessLayer;
using BusinessObjectModel;
using DataAccess;
using LayeredSolution.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LayeredSolution.Controllers
{
    public class LoginController : Controller
    {
       
        private IUserService _userService;
        private IGenericService<LoggerData> _logerSerivce;
        private IMapper mapper;
        
        public LoginController(IUserService IUserService, IMapper mapper, IGenericService<LoggerData> _logerService)
        {
            this._logerSerivce = _logerService;
            this.mapper = mapper;
            this._userService = IUserService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {               
            var user = _userService.FindStudentByCredentials(login.Email.Trim(), login.Password);
            if (user != null)
                {
                    
                    SetCookie(login);
                    List<UserRoles> userRoles = user.Roles;
                    if (userRoles.Where(a => a.RoleId == 8).FirstOrDefault() != null)
                    {
                   
                    CheckIfUserExistIn(user);
                    return RedirectToAction("UserProfile", "Admin");
                   
                    }
                    else if (userRoles.Where(a => a.RoleId == 9).FirstOrDefault() != null)
                    {
                    CheckIfUserExistIn(user);
                    return RedirectToAction("UserProfile", "Professor");
                    }
                    else if (userRoles.Where(a => a.RoleId == 10).FirstOrDefault() != null)
                    {
                    CheckIfUserExistIn(user);
                    return RedirectToAction("UserProfile", "FacultyStudent");
                    }
                    else
                    {
                    CheckIfUserExistIn(user);
                    return RedirectToAction("UserProfile", "HighSchoolStudents");
                    }
                }
            
            return View();
        }

        private LoggerData SetLoggerData(User user) {
            LoggerData loggerData = new LoggerData();
            loggerData.Email = user.Email;
            loggerData.Password = user.Password;
            loggerData.LastLogin = DateTime.Now;
            return loggerData;
        }

        private void CheckIfUserExistIn(User user)
        {
            var s = _logerSerivce.GetAll().Where(a => a.Email.Equals(user.Email)).FirstOrDefault();
            if (s==null)
            {   
                _logerSerivce.Create(SetLoggerData(user));
            }
            else
            {
                s.LastLogin = DateTime.Now;
                _logerSerivce.Update(s);
            }
        }


        private void SetCookie(Login login)
        {
            var Ticket = new FormsAuthenticationTicket(login.Email, true,3000);
            string Encrypt = FormsAuthentication.Encrypt(Ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, Encrypt);
            cookie.Expires = DateTime.Now.AddHours(3000);
            cookie.HttpOnly = true;
            Response.Cookies.Add(cookie);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Login");
        }
    }
}