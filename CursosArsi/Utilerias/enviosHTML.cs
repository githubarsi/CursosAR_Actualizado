using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Librerias;

namespace AdmServer.Utilerias
{
    public class EnviosHTML
    {
        public string CuerpoRegistroMail(string mailEncripta)
        {
            StringBuilder server = new StringBuilder();
            Configuracion rutaConfig = new Configuracion();
            string ruta = rutaConfig.ReturnIni();

            if (File.Exists(ruta))
            {
                Util.GetPrivateProfileString("ConfirmaCorreo", "Empresa", string.Empty, server, 60, ruta);
                string empresa = server.ToString();
                Util.GetPrivateProfileString("ConfirmaCorreo", "Telefono", string.Empty, server, 60, ruta);
                string telefono = server.ToString();
                Util.GetPrivateProfileString("ConfirmaCorreo", "CorreoSoporte", string.Empty, server, 60, ruta);
                string correoSoporte = server.ToString();
                Util.GetPrivateProfileString("ConfirmaCorreo", "RutaConfirmacion", string.Empty, server, 100, ruta);
                string rutaConfirmacion = server.ToString();
                rutaConfirmacion += mailEncripta;

                string body = "<html>";
                body += "<body>";
                body += "<h1>" + empresa + " te da la bienvenida</h1><br/><br/>";
                body += "<p>Por favor dar click ";
                body += "<a href=" + rutaConfirmacion + ">aquí</a>";
                body += " ó copie el siguiente enlace a su navegador para poder registrar su usuario en la aplicación <br/><br/>";
                body += rutaConfirmacion;
                body += "<br/><br/>";
                body += "<p>Gracias.</p><br/><br/>";
                body += "Por favor no responda este correo, si necesita ayuda con el registro, por favor comuniquese al ";
                body += "teléfono " + telefono;
                body += " o al correo " + correoSoporte;
                body += "</body>";
                body += "</html>";

                return body;
            }

            return string.Empty;
        }
    }
}