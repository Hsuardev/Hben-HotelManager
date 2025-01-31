using Capa_de_Negocio;
using Capá_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWebHotel.Controllers
{
    public class CamaController : Controller
    {
        // GET: Cama
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult listarCama()
        {
            CamaBL oCamaBL = new CamaBL();
            return Json(oCamaBL.listarCama(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult filtrarCama(string nombre)
        {
            CamaBL oCamaBL = new CamaBL();
            return Json(oCamaBL.filtrarCama(nombre), JsonRequestBehavior.AllowGet);
        }

        public int EliminarCama(int id)
        {
            CamaBL obj = new CamaBL();
            return obj.EliminarCama(id);
        }

        public int guardarCama(CamaCLS oCamaCLS)
        {
            Console.WriteLine($"ID: {oCamaCLS.idcama}, Nombre: {oCamaCLS.nombre}, Descripción: {oCamaCLS.descripcion}");
            CamaBL obj = new CamaBL();
            return obj.guardarTipoCama(oCamaCLS);
        }
    }
}