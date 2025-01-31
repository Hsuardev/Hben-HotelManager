using Capa_de_Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWebHotel.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult lista()
        {
            ProductoBL obj = new ProductoBL();
            return Json(obj.listarProductos(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult filtrarProductoPorNombre(string nombreproducto)
        {
            ProductoBL obj = new ProductoBL();
            return Json(obj.filtrarProductos(nombreproducto),
                JsonRequestBehavior.AllowGet);
        }
    }
}