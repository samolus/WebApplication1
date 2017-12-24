using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BDD;
using WebApplication1.Models;
using System.Data;
using System.Data.Entity;


namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        private Mycontext db = new Mycontext();

        // GET: Movies
        public ActionResult Index()
        {
            var movies = db.Movies.Include(m => m.Login);
            return View(movies.ToList());
        }

        public ActionResult DetailsContact(int ID)
        {
            foreach (var compagnie in Repository.listContact)
            {
                if (compagnie.id == ID)
                {
                    return View(compagnie);
                }

            }
            return null;
        }

        public ActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create()
        {
            ViewBag.login = new SelectList(db.Login, "id_log", "login");
            return View();
        }

        public ActionResult createMovies(Movies m, Login l)
        {
            try
            {
                byte[] fileData = null;

                if ((m.Files.Count > 0) && (m.Files != null))
                {
                    using (var binaryReader = new BinaryReader(m.Files[0].InputStream))
                    {
                        fileData = binaryReader.ReadBytes(m.Files[0].ContentLength);
                    }
                }

                using (var context = new Mycontext())
                {
                    m.Image = fileData;
                    var movies = context.Movies.Add(m);
                    var login = context.Login.Add(l);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (SystemException)
            {
                using (var context = new Mycontext())
                {

                    var movies = context.Movies.Add(m);
                    var login = context.Login.Add(l);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }


        }
        [HttpPost]
        public ActionResult CreateContact(Contact c)
        {
            c.id = Repository.listContact.Count + 1;
            Repository.listContact.Add(c);
            return RedirectToAction("Index");
        }


        public ActionResult UpdateMovies(int id)
        {
            using (var context = new Mycontext())
            {
                var movies = context.Movies.Where(Movies => Movies.id == id).FirstOrDefault();
                return View(movies);
            }

        }
        [HttpPost]
        public ActionResult UpdateMovie(Movies m)
        {
            using (var context = new Mycontext())
            {
                var movieInDatabase = context.Movies.Where(Movies => Movies.id == m.id).FirstOrDefault();

                movieInDatabase.Name = m.Name;
                movieInDatabase.Nationality = m.Nationality;
                movieInDatabase.Resume = m.Resume;
                movieInDatabase.Actors = m.Actors;
                movieInDatabase.Categories = m.Categories;
                movieInDatabase.Date = m.Date;
                movieInDatabase.Director = m.Director;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            //contact.name = c.name;
            //contact.number = c.number;
            //return RedirectToAction("DetailsContact", new { id = c.id });
        }
        [HttpPost]
        public ActionResult UpdateContact(Contact c)
        {
            var contact = Repository.getContactByID(c.id);
            contact.name = c.name;
            contact.number = c.number;
            return RedirectToAction("DetailsContact", new { id = c.id });
        }

        [HttpPost]
        public ActionResult DeleteMovies(int id)
        {
            using (var context = new Mycontext())
            {
                var movies = context.Movies.Where(Movies => Movies.id == id);
                context.Movies.RemoveRange(movies);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public ActionResult DeleteContact(int Id)
        {

            var contact = Repository.getContactByID(Id);
            Repository.listContact.Remove(contact);
            return RedirectToAction("Index");
        }
    }
}