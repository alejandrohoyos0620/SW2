using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class UsuarioModel
    {
        public int Id_usuario { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        [DisplayName("Nombre")]
        [StringLength(50, ErrorMessage = "El campo supera el limite de caracteres requeridos(50).")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        [DisplayName("Contraseña")]
        [StringLength(50, ErrorMessage = "El campo supera el limite de caracteres requeridos(50).")]
        [Compare("Contraseña2", ErrorMessage = "Las constraseñas no son iguales")]
        public string Contraseña { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        [DisplayName("Confirmar contraseña")]
        [StringLength(50, ErrorMessage = "El campo supera el limite de caracteres requeridos(50).")]
        [Compare("Contraseña", ErrorMessage = "Las constraseñas no son iguales")]
        public string Contraseña2 { get; set; }
    }
}