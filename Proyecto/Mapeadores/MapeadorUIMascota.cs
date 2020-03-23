using ContratosControladorApp1.DTO;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Mapeadores
{
    public class MapeadorUIMascota : MapeadorBaseUi<MascotaDTO, MascotaModel>
    {
        public override MascotaModel MapearT1T2(MascotaDTO entrada)
        {
            return new MascotaModel()
            {
                Id_mascota = entrada.Id_mascota,
                Id_dueño = entrada.Id_dueño,
                Nombre_mascota = entrada.Nombre_mascota,
                Raza = entrada.Raza,
                Pdf_canet = entrada.Pdf_canet
            };
        }

        public override IEnumerable<MascotaModel> MapearT1T2(IEnumerable<MascotaDTO> entrada)
        {
            foreach(var item in entrada)
            {
                yield return MapearT1T2(item);
            }
        }

        public override MascotaDTO MapearT2T1(MascotaModel entrada)
        {
            return new MascotaDTO()
            {
                Id_mascota = entrada.Id_mascota,
                Id_dueño = entrada.Id_dueño,
                Nombre_mascota = entrada.Nombre_mascota,
                Raza = entrada.Raza,
                Pdf_canet = entrada.Pdf_canet
            };
        }

        public override IEnumerable<MascotaDTO> MapearT2T1(IEnumerable<MascotaModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearT2T1(item);
            }
        }
    }
}