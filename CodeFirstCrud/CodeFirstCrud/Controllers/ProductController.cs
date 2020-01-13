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
    public class ProductController : Controller
    {
        DataEntity db = new DataEntity();

        // GET: Product
        public ActionResult Index(string search, int? page)
        {
            List<Product> pro = db.Products.ToList();
            return View(db.Products.Where(x => x.ProductName == search || search == null).ToList().ToPagedList(page ?? 1, 3));
        }

        public ActionResult Create()
        {
            var pro = new Product();
            pro.CatDrop =  db.Categories.ToList();
            return View(pro);
        }

        [HttpPost]
        public ActionResult Create(Product pro)
        {
            // Category objCategory = new Category();
            db.Products.Add(pro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(string Id)
        {
            int ProductId = Convert.ToInt32(Id);
            var pro = db.Products.Find(ProductId);
            return View(pro);
        }

        public ActionResult Edit(string Id)
        {
            int ProductId = Convert.ToInt32(Id);
            var pro = db.Products.Find(ProductId);
            return View(pro);
        }

        [HttpPost]
        public ActionResult Edit(int ID, Product pro)
        {
            db.Entry(pro).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            try
            {
                Product pro = db.Products.SingleOrDefault(x => x.ProductId == Id);
                db.Products.Remove(pro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}