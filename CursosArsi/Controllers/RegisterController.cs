using AdmServer.Utilerias;
using CursosArsi.Models;
using CursosArsi.Servicios;
using Librerias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursosArsi.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VerificaMail(UsuariosEntity user)
        {
            EnviosHTML cuerpo = new EnviosHTML();
            string mensaje = string.Empty;
            string cadenaecripta = Encriptador.Encriptar(user.eMail);
            user.estatus = "N";
            ServiceModel sm = new ServiceModel();
            int respuesta = sm.RegistroUsuario(user);

            if (respuesta > 0)
            {
                string bodyMail = cuerpo.CuerpoRegistroMail(cadenaecripta);

                //EnviaCorreo envMail = new EnviaCorreo
                //{
                //    Correo = user.eMail,
                //    CuerpoMail = bodyMail,
                //};

                //if (envMail.Envio())
                //{
                    return View();
                //}
            }
            else
            {
                switch (respuesta)
                {
                    case -1:
                        mensaje = "Error de procedimiento, Verifique la información capturada";
                        break;
                    case -2:
                        mensaje = "Correo Electrónico ya está registrado por otro usuario";
                        break;
                    case -3:
                        mensaje = "Número Celular ya está registrado por otro usuario";
                        break;
                    default:
                        mensaje = "Error de conexión, Comuniquese con el Administrador";
                        break;
                }
            }

            ViewBag.Error = mensaje;
            return View("Registro");
        }

    }
}