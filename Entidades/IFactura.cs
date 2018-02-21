using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaVirtual.Entidades
{
    public interface IFactura: ICompra
    {
        string Numero { get; set; }
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        DateTime Fecha { get; set; }

        void ImportarLineas(IEnumerable<ILineaFactura> lineas);
    }
}
