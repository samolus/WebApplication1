using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
        public class CommonViewModel
        {
            public IEnumerable<WebApplication1.Models.Movies> Movies { get; set; }
            public IEnumerable<WebApplication1.Models.Login>  Login { get; set; }


        }

}