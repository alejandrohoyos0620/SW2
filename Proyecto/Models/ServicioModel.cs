using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class ServicioModel
    {
        [Required]
        [DisplayName("Id del servicio")]
        public int Servicio { get; set; }
        [Required]
        [DisplayName("Nombre")]
        public string Nombre_servicio { get; set; }
        [Required]
        [DisplayName("Descripcion_servicio")]
        public string descripcion_servicio { get; set; }
        [Required]
        [DisplayName("Imagen")]
        public string Imagen { get; set; }
        [Required]
        [DisplayName("Precio")]
        public int Precio { get; set; }
    }
}