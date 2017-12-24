using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class compagny
    {
        public int id { get; set; }
        public string name { get; set; }
        public string adress { get; set; }


        public List<Contact> contacts { get; set; } = new List<Contact>();
    }


    
   
}