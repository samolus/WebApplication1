using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using WebApplication1.Models;

namespace WebApplication1.BDD
{
    public static class Repository
    {
        public static List<compagny> listCompagny = GetCompgnies();
        public static List<compagny> GetCompgnies()
        {

            


            List<compagny> ls = new List<compagny>();
            compagny compagny1 = new compagny();
            compagny1.adress = "Paris";
            compagny1.id = 1;
            compagny1.name = "Orange";
            compagny compagny2 = new compagny();
            compagny2.adress = "Lyon";
            compagny2.id = 2;
            compagny2.name = "SamComp";
            compagny compagny3 = new compagny();
            compagny3.adress = "Nice";
            compagny3.id = 3;
            compagny3.name = "JulienComp";
            ls.Add(compagny1);
            ls.Add(compagny2);
            ls.Add(compagny3);
            return ls;
        }

        public static List<Contact> listContact = GetContact();
        public static List<Contact> GetContact()
        {
            List<Contact> ls = new List<Contact>();
            Contact contact1 = new Contact();
            contact1.id = 1;
            contact1.name = "Orange SAV";
            contact1.number = "012345679";
            Contact contact2 = new Contact();
            contact2.id = 2;
            contact2.name = "SAM SAV";
            contact2.number = "123456789";
            Contact contact3 = new Contact();
            contact3.id = 3;
            contact3.name = "Julien SAV";
            contact3.number = "012345679";
            ls.Add(contact1);
            ls.Add(contact2);
            ls.Add(contact3);
            return ls;
        }
        public static Contact getContactByID(int Id)
        {
            var contact = Repository.listContact.Where(cont => cont.id == Id).Single();
            return contact;
        }
        public static compagny getCompagnyByID(int Id)
        {
            var compagnie = Repository.listCompagny.Where(comp => comp.id == Id).Single();
            return compagnie;
        }
    }
}