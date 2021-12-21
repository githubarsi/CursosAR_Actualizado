using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CursosArsi.Models
{
    public class Modulos
    {
        [Display(Name = "id modulo")]
        public int id_modulo { get; set; }
        [Display(Name = "Modulo")]
        public string descripcion_modulo { get; set; }
        [Display(Name = "URL")]
        public string url_modulo { get; set; }
    }
}