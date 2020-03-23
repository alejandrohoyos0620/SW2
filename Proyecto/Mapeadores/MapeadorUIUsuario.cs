using ContratosControladorApp1.DTO;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Mapeadores
{
    public class MapeadorUIUsuario : MapeadorBaseUi<UsuarioDTO, UsuarioModel>
    {
        public override UsuarioModel MapearT1T2(UsuarioDTO entrada)
        {
            return new UsuarioModel()
            {
                Id_usuario = entrada.Id_usuario,
                Nombre = entrada.Nombre,
                Contraseña = entrada.Contraseña
            };
        }

        public override IEnumerable<UsuarioModel> MapearT1T2(IEnumerable<UsuarioDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearT1T2(item);

            }
        }

        public override UsuarioDTO MapearT2T1(UsuarioModel entrada)
        {
            return new UsuarioDTO()
            {
                Id_usuario = entrada.Id_usuario,
                Nombre = entrada.Nombre,
                Contraseña = entrada.Contraseña

            };
        }

        public override IEnumerable<UsuarioDTO> MapearT2T1(IEnumerable<UsuarioModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearT2T1(item);

            }
        }
    }
}