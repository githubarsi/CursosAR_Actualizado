using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursosArsi.Controllers
{
    public class CerrarSController : Controller
    {
        // GET: CerrarS
        public ActionResult Logoff()
        {

            Session["usuario"] = null;
            Session["id_usuario"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}