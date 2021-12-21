using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Diagnostics;

namespace AdmServer.Utilerias
{
    public class RegistraLog
    {

        public void Guardar(string referencia, string mensaje)
        {
            string fecha = System.DateTime.Now.ToString("yyyyMMdd");
            string hora = System.DateTime.Now.ToString("HH:mm:ss");
            string path = HttpContext.Current.Server.MapPath("~/Log/" + fecha + ".txt");

            StreamWriter sw = new StreamWriter(path, true);

            StackTrace stacktrace = new StackTrace();
            sw.WriteLine(referencia + " " + hora);
            sw.WriteLine(stacktrace.GetFrame(1).GetMethod().Name + " - " + mensaje);
            sw.WriteLine("---------------------------------------------------------------------------------------");

            sw.Flush();
            sw.Close();
        }
    }
}