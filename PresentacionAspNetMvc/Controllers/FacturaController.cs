using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual.Entidades;
using TiendaVirtual.LogicaNegocio;


namespace PresentacionAspNetMvc.Controllers
{
    public class FacturaController : Controller
    {
        // GET: Factura

        public ActionResult MFactura()
        {
            ICarrito carrito = (ICarrito)HttpContext.Session["carrito"];
            //ILogicaNegocio ln = new LogicaNegocio();
            ILogicaNegocio ln = (ILogicaNegocio)HttpContext.Application["logicaNegocio"];
            IFactura f = ln.FacturarCarrito(carrito);
            return View("Index", f);
        }
    }
}