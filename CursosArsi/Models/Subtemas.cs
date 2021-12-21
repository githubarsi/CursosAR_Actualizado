using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CursosArsi.Models
{
    public class Subtemas
    {
        [Display(Name = "id SubTema")]
        public int id_subtema { get; set; }
        [Display(Name = "Subtema")]
        public string descripcion_subtema { get; set; }
        [Display(Name = "URL")]
        public string url_subtema { get; set; }
    }
}