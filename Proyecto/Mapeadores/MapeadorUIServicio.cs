using ContratosControladorApp1.DTO;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Mapeadores
{
    public class MapeadorUIServicio : MapeadorBaseUi<ServicioDTO, ServicioModel>
    {
        public override ServicioModel MapearT1T2(ServicioDTO entrada)
        {
            return new ServicioModel()
            {
                Servicio = entrada.Servicio,
                Nombre_servicio = entrada.Nombre_servicio,
                descripcion_servicio = entrada.descripcion_servicio,
                Imagen = entrada.Imagen,
                Precio = entrada.Precio
            };
        }

        public override IEnumerable<ServicioModel> MapearT1T2(IEnumerable<ServicioDTO> entrada)
        {
            foreach(var item in entrada)
            {
                yield return MapearT1T2(item);
            }
        }

        public override ServicioDTO MapearT2T1(ServicioModel entrada)
        {
            return new ServicioDTO()
            {
                Servicio = entrada.Servicio,
                Nombre_servicio = entrada.Nombre_servicio,
                descripcion_servicio = entrada.descripcion_servicio,
                Imagen = entrada.Imagen,
                Precio = entrada.Precio

            };
        }

        public override IEnumerable<ServicioDTO> MapearT2T1(IEnumerable<ServicioModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearT2T1(item);
            }
        }
    }
}