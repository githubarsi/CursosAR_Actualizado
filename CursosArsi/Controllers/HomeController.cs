using System;
using System.Configuration;
using System.Web.Mvc;
using AdmServer.Models;
using System.Collections.Generic;
using CursosArsi.Utilerias;
using CursosArsi.Models;
using CursosArsi.Servicios;
using CursosArsi.WebService;


namespace CursosArsi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string usr, string pwd)
        {
            ViewBag.Message = "Ingreso";

            if (usr != null)
            {
                Autenticacion clsUser = new Autenticacion();
                int intSeccionUser = clsUser.UsuarioValido(usr, pwd);
                

                switch (intSeccionUser)
                {
                    case -1:
                        return RedirectToAction("Index");
                    default:
                        Session["usuario"] = usr;
                        if (usr == "diana.sn_@hotmail.com")
                        {
                            return RedirectToAction("../Cursos/Modulos");
                        }
                        return RedirectToAction("Cursos");
                }
            }

            mensajero ms = new mensajero();
            ms.EnviaMensaje();

            return View();
        }

        public ActionResult Cursos()
         {
            int idUsuario = Convert.ToInt32(Session["id_usuario"]);
            return View();
        } 
    }
}