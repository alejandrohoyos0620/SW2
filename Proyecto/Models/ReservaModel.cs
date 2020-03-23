using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class ReservaModel
    {
        public int Id_reserva { get; set; }
        public int Id_cliente { get; set; }
        public int Id_reservacion { get; set; }
        public DateTime fecha { get; set; }
        public TimeSpan hora { get; set; }
        public int Total { get; set; }
        public string Estadoreserva { get; set; }
        public string Tipopago { get; set; }
        public String Factura { get; set; }
    }
}