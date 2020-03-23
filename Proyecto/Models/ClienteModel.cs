using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class ClienteModel
    {
        public int Id_cliente { get; set; }
        public string Direccion { get; set; }
        public string Correo1 { get; set; }
    }
}