using System;
using System.Collections.Generic;

namespace Practica20240305.Models
{
    public partial class DetFacturaVenta
    {
        public int Id { get; set; }
        public int IdFacturaVenta { get; set; }
        public string Producto { get; set; } = null!;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public virtual FacturaVenta IdFacturaVentaNavigation { get; set; } = null!;
    }
}
