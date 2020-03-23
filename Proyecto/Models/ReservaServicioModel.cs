using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class ReservaServicioModel
    {
        public int Id_reservaServicio { get; set; }
        public int Id_servicio { get; set; }
        public int Id_mascota { get; set; }
    }
}