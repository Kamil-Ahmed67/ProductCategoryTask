using ProCatLabTask.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProCatLabTask.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var db = new GroceryStoreEntities();
            var data = db.Products.ToList();

            return View(data);
        }
        [HttpGet]
        public ActionResult Create() 
        { 
            var db=new GroceryStoreEntities();
            ViewBag.Categories=db.Categories.ToList();
            return View();

        }
        [HttpPost]
        public ActionResult Create(Product p)
        { 
            var db=new GroceryStoreEntities();
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db=new GroceryStoreEntities();
            var data=db.Products.Find(id);
            return View(data);  
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            var db=new GroceryStoreEntities();
            var ex = db.Products.Find(p.P_Id);
            ex.P_Name = p.P_Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var db=new GroceryStoreEntities();
            var data= db.Products.Find(id);
            db.Products.Remove(data);   
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}