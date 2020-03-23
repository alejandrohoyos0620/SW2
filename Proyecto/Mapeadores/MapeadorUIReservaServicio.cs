using ContratosControladorApp1.DTO;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Mapeadores
{
    public class MapeadorUIReservaServicio : MapeadorBaseUi<ReservaServicioDTO, ReservaServicioModel>
    {
        public override ReservaServicioModel MapearT1T2(ReservaServicioDTO entrada)
        {
            return new ReservaServicioModel()
            {
                Id_reservaServicio = entrada.Id_reservaServicio,
                Id_mascota = entrada.Id_mascota,
                Id_servicio = entrada.Id_servicio
            };
        }

        public override IEnumerable<ReservaServicioModel> MapearT1T2(IEnumerable<ReservaServicioDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearT1T2(item);

            }
        }

        public override ReservaServicioDTO MapearT2T1(ReservaServicioModel entrada)
        {
            return new ReservaServicioDTO()
            {
                Id_reservaServicio = entrada.Id_reservaServicio,
                Id_mascota = entrada.Id_mascota,
                Id_servicio = entrada.Id_servicio
            };
        }

        public override IEnumerable<ReservaServicioDTO> MapearT2T1(IEnumerable<ReservaServicioModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearT2T1(item);

            }
        }
    }
}