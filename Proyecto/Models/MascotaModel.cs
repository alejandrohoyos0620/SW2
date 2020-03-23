using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class MascotaModel
    {
        public int Id_mascota { get; set; }
        public int Id_dueño { get; set; }
        public string Nombre_mascota { get; set; }
        public string Raza { get; set; }
        public string Pdf_canet { get; set; }
    }
}