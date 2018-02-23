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
            //ILogicaNegocio ln = new LogicaNegocio(); //Si crear nuevo objeto entra en constructor vacio de lineaNegocio y no debe
            ILogicaNegocio ln = (ILogicaNegocio)HttpContext.Application["logicaNegocio"];
            if (carrito.Usuario == null) { return RedirectToAction("Index", "Productos"); } //orde: medoto Controlador }
            IFactura f = ln.FacturarCarrito(carrito);           
            return View("Index", f);
        }
    }
}