using AutoMapper;
using BusinessLayer;
using BusinessObjectModel;
using LayeredSolution.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayeredSolution.Controllers
{
    public class GenericController<Model, ViewModel> : Controller where Model : class where ViewModel : class
    {
        private readonly IGenericAppService<Model, ViewModel> _genericAppService;

        public GenericController(IGenericAppService<Model, ViewModel> genericAppService)
        {
            this._genericAppService = genericAppService;
        }

        public virtual ActionResult Index()
        {
          
            var model = _genericAppService.GetAllStudents();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Create(Model student)
        {
            if (ModelState.IsValid)
            {
               
                _genericAppService.Create(student);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Model student)
        {
            if (ModelState.IsValid)
            {
                _genericAppService.Update(student);
                return RedirectToAction("index");
            }
            return View();
        }


        [HttpGet]
        public virtual ActionResult Delete(int id)
        {
            var model = _genericAppService.findStudent(id);
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Delete(int id, FormCollection formCollection)
        {
            _genericAppService.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public virtual ActionResult Details(int id)
        {
            var model = _genericAppService.findStudent(id);
            return View("Edit", model);
        }

      
        [HttpGet]
        public virtual ActionResult Edit(int id)     
        {   
            var  model = _genericAppService.findStudent(id);
            
            if (model != null)
            {
                return View("Edit", model);
            }
            return RedirectToAction("Index");
        }

        //public ActionResult UserProfile(UserViewModel userViewModel)
        //{
        //    int id = userViewModel.Id;
        //    var model = IGenericService.findStudent(id);
        //    return View(model);
        //}

    }
}