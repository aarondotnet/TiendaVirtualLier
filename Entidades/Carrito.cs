namespace TiendaVirtual.Entidades
{
    public class Carrito: Compra, ICarrito
    {
        public Carrito(IUsuario usuario) : base(usuario) { }
    }
}
