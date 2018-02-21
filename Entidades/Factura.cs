using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaVirtual.Entidades
{
    public class Factura : Compra, IFactura
    {
        public Factura() : base(null)
        {
        }
        public Factura(IUsuario usuario) : base(usuario)
        {
        }

        public string Numero { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Fecha { get; set; }

        public void ImportarLineas(IEnumerable<ILineaFactura> lineas)
        {
            lineasFactura.Clear();

            foreach (ILineaFactura linea in lineas)
                lineasFactura.Add(linea.Producto.Id, linea);
        }

        public override string ToString()
        {
            return $"{Numero}\n{Fecha}\n{Usuario}\n{string.Join("\n",LineasFactura)}\n{ImporteSinIva}\n{Iva}\n{Total}";
        }
    }
}
