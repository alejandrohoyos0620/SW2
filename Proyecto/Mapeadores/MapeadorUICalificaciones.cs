using ContratosControladorApp1.DTO;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Mapeadores
{
    public class MapeadorUICalificaciones : MapeadorBaseUi<CalificacionesDTO, CalificacionesModel>
    {
        public override CalificacionesModel MapearT1T2(CalificacionesDTO entrada)
        {
            return new CalificacionesModel()
            {
                Id_calificacion = entrada.Id_calificacion,
                Id_cliente = entrada.Id_cliente,
                Id_servicio = entrada.Id_servicio,
                calificacion = entrada.calificacion,
                comentario = entrada.comentario
            };
        }

        public override IEnumerable<CalificacionesModel> MapearT1T2(IEnumerable<CalificacionesDTO> entrada)
        {
            foreach(var item in entrada)
            {
                yield return MapearT1T2(item);
            }
        }

        public override CalificacionesDTO MapearT2T1(CalificacionesModel entrada)
        {
            return new CalificacionesDTO()
            {
                Id_calificacion = entrada.Id_calificacion,
                Id_cliente = entrada.Id_cliente,
                Id_servicio = entrada.Id_servicio,
                calificacion = entrada.calificacion,
                comentario = entrada.comentario
            };
        }

        public override IEnumerable<CalificacionesDTO> MapearT2T1(IEnumerable<CalificacionesModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearT2T1(item);
            }
        }
    }
}