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
    [Table("login")]
    public class Login
    {
        [Key]
        [Column("id_log")]
        public int id_log { get; set; }
        [Column("login")]
        public string login { get; set; }

        public virtual ICollection<Movies> Movies { get; set; }


    }
    [Table("movies_project")]
    public class Movies
    {
        [Key]
        [Column("ID")]
        public int id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Date")]
        public Int16 Date { get; set; }
        [Column("Categories")]
        public string Categories { get; set; }
        [Column("Resume")]
        public string Resume { get; set; }
        [Column("Actors")]
        public string Actors { get; set; }
        [Column("Nationality")]
        public string Nationality { get; set; }
        [Column("Image")]
        public Byte[] Image { get; set; }
        [Column("Director")]
        public string Director { get; set; }
        [Column("id_log")]
        public int id_log { get; set; }
        [NotMapped]
        public List<HttpPostedFileBase> Files { get; set; }

        public virtual Login Login { get; set; }
        public Movies()
        {
            Files = new List<HttpPostedFileBase>();

        }



    }
}