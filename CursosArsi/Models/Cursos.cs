using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CursosArsi.Models
{
    public class Cursos
    {
        [Display(Name = "Producto")]
        public int Id_producto { get; set; }
        [Display(Name = "nombre")]
        public string descripcion_producto { get; set; }
     
        [Display(Name = "estatus")]
        public string marca { get; set; }
   
    }
}