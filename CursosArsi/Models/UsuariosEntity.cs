using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursosArsi.Models
{
    public class UsuariosEntity
    {
        public int Id { get; set; }
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string eMail { get; set; }
        public string eMailC { get; set; }
        public string contrasena { get; set; }
        public string contrasenaC { get; set; }
        public string cp { get; set; }
        public string calle { get; set; }
        public string numeroExt { get; set; }
        public string numeroInt { get; set; }
        public string colonia { get; set; }
        public string municipio { get; set; }
        public string estado { get; set; }
        public string telefonoContacto { get; set; }
        public string telefonoWhats { get; set; }
        public string estatus { get; set; }
    }
}