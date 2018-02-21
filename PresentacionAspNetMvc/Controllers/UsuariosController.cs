using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual.Entidades;
using TiendaVirtual.LogicaNegocio;

namespace PresentacionAspNetMvc.Controllers
{
    public class UsuariosController : Controller
    {
        public ActionResult Login(Usuario usuario)
        {
            var ln = (ILogicaNegocio)HttpContext.Application["logicaNegocio"];

            IUsuario usuarioCompleto = ln.ValidarUsuarioYDevolverUsuario(
                usuario.Nick, usuario.Password);

            HttpContext.Session["usuario"] = usuarioCompleto;

            ((ICarrito)HttpContext.Session["carrito"]).Usuario = usuarioCompleto;

            return Redirect("/");
        }
    }
}