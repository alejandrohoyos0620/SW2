using ContratosControladorApp1.DTO;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Mapeadores
{
    public class MapeadorUICliente : MapeadorBaseUi<ClienteDTO, ClienteModel>
    {
        public override ClienteModel MapearT1T2(ClienteDTO entrada)
        {
            return new ClienteModel()
            {
                Id_cliente = entrada.Id_cliente,
                Direccion = entrada.Direccion,
                Correo1 = entrada.Correo1
            };
        }

        public override IEnumerable<ClienteModel> MapearT1T2(IEnumerable<ClienteDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearT1T2(item);
            }
        }

        public override ClienteDTO MapearT2T1(ClienteModel entrada)
        {
            return new ClienteDTO()
            {
                Id_cliente = entrada.Id_cliente,
                Direccion = entrada.Direccion,
                Correo1 = entrada.Correo1

            };
        }

        public override IEnumerable<ClienteDTO> MapearT2T1(IEnumerable<ClienteModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearT2T1(item);
            }
        }
    }
}