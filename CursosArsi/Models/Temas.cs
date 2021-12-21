using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CursosArsi.Models
{
    public class Temas
    {
        [Display(Name = "id Tema")]
        public int id_tema { get; set; }
        [Display(Name = "Tema")]
        public string descripcion_tema { get; set; }
        [Display(Name = "URL")]
        public string url_tema { get; set; }
    }
}