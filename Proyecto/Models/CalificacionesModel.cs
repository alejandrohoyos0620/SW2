using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class CalificacionesModel
    {
        public int Id_calificacion { get; set; }
        public int Id_servicio { get; set; }
        public int Id_cliente { get; set; }
        public int calificacion { get; set; }
        public string comentario { get; set; }
    }
}