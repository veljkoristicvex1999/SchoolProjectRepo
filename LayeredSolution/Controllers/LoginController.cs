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
        private IMapper mapper;
        
        public LoginController(IUserService IUserService, IMapper mapper)
        {
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
                    return RedirectToAction("UserProfile", "Admin");
                    }
                    else if (userRoles.Where(a => a.RoleId == 9).FirstOrDefault() != null)
                    {
                        return RedirectToAction("UserProfile", "Professor");
                    }
                    else if (userRoles.Where(a => a.RoleId == 10).FirstOrDefault() != null)
                    {
                        return RedirectToAction("UserProfile", "FacultyStudent");
                    }
                    else
                    {
                        return RedirectToAction("UserProfile", "HighSchoolStudents");
                    }
                }
            
            return View();
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