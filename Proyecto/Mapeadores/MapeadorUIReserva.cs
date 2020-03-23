using ContratosControladorApp1.DTO;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Mapeadores
{
    public class MapeadorUIReserva : MapeadorBaseUi<ReservaDTO, ReservaModel>
    {
        public override ReservaModel MapearT1T2(ReservaDTO entrada)
        {
            return new ReservaModel()
            {
                Id_reserva = entrada.Id_reserva,
                Id_reservacion = entrada.Id_reservacion,
                Id_cliente = entrada.Id_cliente,
                Estadoreserva = entrada.Estadoreserva,
                fecha = entrada.fecha,
                hora = entrada.hora,
                Factura = entrada.Factura,
                Tipopago = entrada.Tipopago,
                Total = entrada.Total
            };
        }

        public override IEnumerable<ReservaModel> MapearT1T2(IEnumerable<ReservaDTO> entrada)
        {
            foreach(var item in entrada)
            {
                yield return MapearT1T2(item);

            }
        }

        public override ReservaDTO MapearT2T1(ReservaModel entrada)
        {
            return new ReservaDTO()
            {
                Id_reserva = entrada.Id_reserva,
                Id_reservacion = entrada.Id_reservacion,
                Id_cliente = entrada.Id_cliente,
                Estadoreserva = entrada.Estadoreserva,
                fecha = entrada.fecha,
                hora = entrada.hora,
                Factura = entrada.Factura,
                Tipopago = entrada.Tipopago,
                Total = entrada.Total
            };
        }

        public override IEnumerable<ReservaDTO> MapearT2T1(IEnumerable<ReservaModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearT2T1(item);

            }
        }
    }
}