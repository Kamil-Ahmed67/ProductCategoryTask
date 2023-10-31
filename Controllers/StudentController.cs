using Crude_Application.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crude_Application.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var db = new Demo_TaskEntities();
            var data=db.Students.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var db =new Demo_TaskEntities();
            ViewBag.Departments = db.Departments.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s) 
        {
            var db=new Demo_TaskEntities();
            db.Students.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}