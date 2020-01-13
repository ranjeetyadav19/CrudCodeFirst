
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace CodeFirstCrud.Controllers
{

    public class CategoryController : Controller
    {
        DataEntity db = new DataEntity();

        // GET: Category
        public ActionResult Index(string search ,int? page)
        {
            List<Category> cat = db.Categories.ToList();
            return View(db.Categories.Where(x=>x.CategoryName == search || search == null).ToList().ToPagedList(page?? 1,3));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( Category cat)
        {
            try
            {
                db.Categories.Add(cat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           catch
            {
                return View();
            }
            
        }

        public ActionResult Details( string Id)
        {
            int CategoryId = Convert.ToInt32(Id);
            var cat = db.Categories.Find(CategoryId);
            return View(cat);
        }

        public ActionResult Edit(string Id)
        {
            int CategoryId = Convert.ToInt32(Id);
            var cat = db.Categories.Find(CategoryId);
            return View(cat);
        }

        [HttpPost]
        public ActionResult Edit(int ID ,Category cat)
        {
            db.Entry(cat).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            try
            {
                Category cat = db.Categories.SingleOrDefault(x => x.CategoryId == Id);
                db.Categories.Remove(cat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }
    }
}