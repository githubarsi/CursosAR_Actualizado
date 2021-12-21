using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursosArsi.Utilerias;
using CursosArsi.Models;

namespace CursosArsi.Controllers
{
    public class CursosController : Controller
    {
        // GET: Cursos
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult VisualizadorCursos(int idCurso=0, string nombreCurso="")
        {

            Session["idCurso"] = idCurso;
            Session["nombreCurso"] = nombreCurso;
            return View();
        }
        CursosConsulta admin = new CursosConsulta();
        public ActionResult Modulos()
        {

            IEnumerable<Cursos> lista = admin.ListadoCursos();
            return View(lista);


        }
        public ActionResult IngresarModulo(int id=0)
        {
            
            Session["id_lista_modulos"]=id;
            IEnumerable<Modulos> lista = admin.ListadoModulos(id);
            return View(lista);

        }
        public ActionResult EditarModulo(int id)
        {
            string letra = "M";
            Modulos modelo= admin.ConsultaModulos(id, letra);

            return View(modelo);
          

        }

        public ActionResult EditarModuloRespuesta(Modulos datosModelo)
        {

            int respuesta = guardar.EditarModulos(datosModelo);
            if (respuesta == 2)
            {
                return RedirectToAction("IngresarModulo", new { id = Session["id_lista_modulos"] });

            }
            else
            {
                return RedirectToAction("IngresarModulo", new { id = Session["id_lista_modulos"] });

            }

        }
        public ActionResult EliminarModulo(int id)
        {
            string mensaje = string.Empty;
            string letra = "M";
            int respuesta = guardar.ElminarMTS(id,letra);
            if (respuesta == 0)
            {
                return RedirectToAction("IngresarModulo", new { id = Session["id_lista_modulos"] });

            }
            else
            {
                mensaje = "No se pudo eliminar registro";
                ViewBag.Message = mensaje;
                return RedirectToAction("IngresarModulo", new { id = Session["id_lista_modulos"] });
            }



        }
        IngresarDatosCurso guardar = new IngresarDatosCurso();
        public ActionResult Guardar()
        {
 
            return View();
        }

        public ActionResult Nuevo(Modulos modelo)
        {
            int idproducto = Convert.ToInt32(Session["id_lista_modulos"]);
            int respuesta = guardar.Guardar(modelo, idproducto);
            
            if (respuesta == 0)
            {
                return RedirectToAction("IngresarModulo", new { id = Session["id_lista_modulos"] });

            }
            else
            {
                return View("Guardar", modelo);
            }

        }
        public ActionResult ModulosNuevo()
        {

            return View();
        }
        public ActionResult Temas(int id=0)
        {
            Session["id_lista_tema"] = id;
            IEnumerable<Temas> lista = admin.ListadoTemas(id);
            return View(lista);
        }

        public ActionResult GuardarTema()
        {

            return View();
        }
        public ActionResult NuevoTema(Temas modelo)
        {
            int idTema = Convert.ToInt32(Session["id_lista_tema"]);
            int respuesta = guardar.GuardarTemas(modelo, idTema);
            
            if (respuesta == 0)
            {
                return RedirectToAction("Temas", new { id = Session["id_lista_tema"] });

            }
            else
            {
                return View("GuardarTema", modelo);
            }

        }
        public ActionResult EditarTemas(int id)
        {
            string letra = "T";
            Temas modelo = admin.ConsultaTemas(id, letra);

            return View(modelo);


        }

        public ActionResult EditarTemaRespuesta(Temas datosTema)
        {

            int respuesta = guardar.EditarTemas(datosTema);
            if (respuesta == 2)
            {
                return RedirectToAction("Temas", new { id = Session["id_lista_tema"] });

            }
            else
            {
                return RedirectToAction("Temas", new { id = Session["id_lista_tema"] });

            }

        }
        public ActionResult EliminarTema(int id)
        {
            string letra = "T";
            int respuesta = guardar.ElminarMTS(id, letra);
            if (respuesta == 1)
            {
                return RedirectToAction("Temas", new { id = Session["id_lista_tema"] });

            }
            else
            {
                string mensaje = "No se pudo eliminar registro";
                return RedirectToAction("Temas", new { id = Session["id_lista_tema"] });
            }

        }
        public ActionResult SubTemas(int id)
        {
            Session["id_lista_subtema"] = id;
            IEnumerable<Subtemas> lista = admin.ListadoSubTemas(id);
            return View(lista);
        }
        public ActionResult GuardarSubTema()
        {

            return View();
        }
        public ActionResult NuevoSubTema(Subtemas modelo)
        {
            int idSubTema = Convert.ToInt32(Session["id_lista_subtema"]);
            int respuesta = guardar.GuardarSubTemas(modelo, idSubTema);

            if (respuesta == 0)
            {
                return RedirectToAction("SubTemas", new { id = Session["id_lista_subtema"] });

            }
            else
            {
                return View("GuardarSubTema", modelo);
            }

        }
        public ActionResult EliminarSubtema(int id)
        {
            string letra = "S";
            int respuesta = guardar.ElminarMTS(id, letra);
            if (respuesta == 2)
            {
                return RedirectToAction("SubTemas", new { id = Session["id_lista_subtema"] });

            }
            else
            {
                 string mensaje = "No se pudo eliminar registro";

                return RedirectToAction("SubTemas", new { id = Session["id_lista_subtema"] });
            }

        }
        public ActionResult EditarSubTemas(int id)
        {
            string letra = "S";
            Models.Subtemas modelo = admin.ConsultaSubtemas(id, letra);

            return View(modelo);


        }

        public ActionResult EditarSubTemaRespuesta(Subtemas datosSubtema)
        {

            int respuesta = guardar.EditarSubTemas(datosSubtema);
            if (respuesta == 2)
            {
                return RedirectToAction("SubTemas", new { id = Session["id_lista_subtema"] });

            }
            else
            {
                return RedirectToAction("SubTemas", new { id = Session["id_lista_subtema"] });

            }

        }
    }
}