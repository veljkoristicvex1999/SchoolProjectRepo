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
        private readonly IGenericAppService<Model, ViewModel> IGenericService;

        public GenericController(IGenericAppService<Model, ViewModel> IGenericService)
        {
            this.IGenericService = IGenericService;
        }

        public virtual ActionResult Index()
        {
          
            var model = IGenericService.GetAllStudents();
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
               
                IGenericService.Create(student);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Model student)
        {
            if (ModelState.IsValid)
            {
                IGenericService.Update(student);
                return RedirectToAction("index");
            }
            return View();
        }


        [HttpGet]
        public virtual ActionResult Delete(int id)
        {
            var model = IGenericService.findStudent(id);
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Delete(int id, FormCollection formCollection)
        {
            IGenericService.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public virtual ActionResult Details(int id)
        {
            var model = IGenericService.findStudent(id);
            return View("Edit", model);
        }

      
        [HttpGet]
        public virtual ActionResult Edit(int id)     
        {   
            var  model = IGenericService.findStudent(id);
            
            if (model != null)
            {
                return View("Edit", model);
            }
            return RedirectToAction("Index");
        }
        
    }
}