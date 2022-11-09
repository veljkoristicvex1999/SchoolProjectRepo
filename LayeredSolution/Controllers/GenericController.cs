using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayeredSolution.Controllers
{
    public class GenericController<T> : Controller where T : class
    {
        private readonly IGenericService<T> IGenericService;

        public GenericController(IGenericService<T> IGenericService)
        {
            this.IGenericService = IGenericService;
        }

        public ActionResult Index()
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
        public  ActionResult Create(T student)
        {
            if (ModelState.IsValid)
            {
                IGenericService.Create(student);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = IGenericService.findStudent(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = IGenericService.findStudent(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            IGenericService.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = IGenericService.findStudent(id);
            if (model != null)
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(T student)
        {
            if (ModelState.IsValid)
            {
                IGenericService.Update(student);
                return RedirectToAction("index");
            }
            return View();
        }
    }
}