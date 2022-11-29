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
        private IUserService IUserService;
       
        
        public LoginController(IUserService IUserService)
        {
            this.IUserService = IUserService;
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
                var user = IUserService.FindStudentByCredentials(login.Email.Trim(), login.Password);
            if (user != null)
                {
                    SetCookie(login);
                    List<UserRoles> userRoles = user.Roles;
                    if (userRoles.Where(a => a.RoleId == 8).FirstOrDefault() != null)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (userRoles.Where(a => a.RoleId == 9).FirstOrDefault() != null)
                    {
                        return RedirectToAction("Index", "Professor");
                    }
                    else if (userRoles.Where(a => a.RoleId == 10).FirstOrDefault() != null)
                    {
                        return RedirectToAction("Index", "FacultyStudent");
                    }
                    else
                    {
                        return RedirectToAction("Index", "HighSchoolStudents");
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