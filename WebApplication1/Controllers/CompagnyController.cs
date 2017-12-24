using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BDD;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CompagnyController : Controller
    {
        public ActionResult Details(int ID)
        {
            foreach(var compagnie in Repository.listCompagny)
            {
                if (compagnie.id == ID)
                {
                    return View(compagnie);
                }
                
            }
            return null;
        }
        // GET: Compagny
        public ActionResult Index()
        {
            using (var context = new Mycontext())
            {
                var movies = context.Movies.ToList();
                //return View(movies);

            }
            return View(Repository.listCompagny);
        }

        public ActionResult CreateLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateLogin(Login l)
        {
            using (var context = new Mycontext())
            {
                var login = context.Login.Add(l);
                context.SaveChanges();
                return View("Sucess");
            }
        }
        [HttpGet]
        public ActionResult Update(int Id)
        {
            var compagnie = Repository.getCompagnyByID(Id);
            return View(compagnie);
        }
        [HttpPost]
        public ActionResult Update(compagny c)
        {
            var compagnie = Repository.getCompagnyByID(c.id);
            compagnie.name = c.name;
            compagnie.adress = c.adress;
            return RedirectToAction("Details", new {id = c.id});
        }
       
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            var compagnie = Repository.getCompagnyByID(Id);
            Repository.listCompagny.Remove(compagnie);
            return RedirectToAction("Index");
        }
    }
}