using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual.Entidades;
using TiendaVirtual.LogicaNegocio;

namespace PresentacionAspNetMvc.Controllers
{
    public class CarritoController : Controller
    {
        // GET: Carrito
        public ActionResult Index()
        {
            ICarrito carrito = (ICarrito)HttpContext.Session["carrito"];
            return View(carrito);
        }

        public ActionResult AgregarProducto(int id, int cantidad)
        {
            ILogicaNegocio ln = (ILogicaNegocio)HttpContext.Application["logicaNegocio"];

            ICarrito carrito = (ICarrito)HttpContext.Session["carrito"];

            IProducto producto = ln.BuscarProductoPorId(id);

            ln.AgregarProductoACarrito(producto, cantidad, carrito);

            return RedirectToAction("Index");
        }
        //public ActionResult Prueba()
        //{
        //    RedirectToAction("MFactura", "Factura");
        //}
    }
}