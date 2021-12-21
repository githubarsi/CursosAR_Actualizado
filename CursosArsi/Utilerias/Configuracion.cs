using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdmServer.Utilerias
{
    public class Configuracion
    {
        private string _usuario;

        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public string ReturnIni()
        {
            string strConfig = HttpContext.Current.Server.MapPath("~/conect/config.ini");
            return strConfig;
        }
    }
}