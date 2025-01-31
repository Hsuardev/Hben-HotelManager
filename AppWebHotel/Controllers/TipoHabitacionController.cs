using Capa_de_Negocio;
using Capá_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWebHotel.Controllers
{
    public class TipoHabitacionController : Controller
    {
        // GET: TipoHabitacion
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inicio()
        {
            return View();
        }
        public ActionResult VistaPruebaInicio()
        {
            return View();
        }
       // public List<TipoHabitacionCLS> lista()
       // {
         //   TipoHabitacionBL obj = new TipoHabitacionBL();
           // return obj.listarTipoHabitacion();
        //}

        public JsonResult lista()
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return Json(obj.listarTipoHabitacion(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult filtrarTipoHabitacionPorNombre(string nombrehabitacion)
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return Json(obj.filtrarTipoHabitacion(nombrehabitacion), JsonRequestBehavior.AllowGet);
        }
        public int guardarDatos(TipoHabitacionCLS oTipoHabitacionCLS)
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return obj.guardarTipoHabitacion(oTipoHabitacionCLS);

        }
        public JsonResult recuperarTipoHabitacion(int id)
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return Json(obj.recuperarTipoHabitacion(id), JsonRequestBehavior.AllowGet);

        }

        public int eliminarTipoHabitacion(int id)
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return obj.eliminarTipoHabitacion(id);
        }

    }
}