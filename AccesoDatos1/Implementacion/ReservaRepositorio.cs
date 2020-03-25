using AccesoDatos1.Mapeadores;
using AccesoDatos1.Modelo;
using ContratoAccesoDatos1.Contratos;
using ContratoAccesoDatos1.RkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos1.Implementacion
{
    public class ReservaRepositorio : IReserva
    {
        public bool ActualizarReserva(ReservaDBModel reserva)
        {
            throw new NotImplementedException();
        }

        public Boolean BuscarReserva(DateTime fecha, TimeSpan hora)
        {
            using (petServicesEntities1 db = new petServicesEntities1())
            {
                var Query = db.reservas.Where(u => u.fecha == fecha && u.hora == hora).Select(p => p.id_reservacion);
                if (Query.Count() > 0)
                {
                    return false;
                }
                return true;
            }
        }

        public IEnumerable<ReservaDBModel> ConsultaReserva()
        {
            using (petServicesEntities1 db = new petServicesEntities1())
            {
                IList<reserva> listadoReservaBD = db.reservas.ToList();
                var lista = new MapeadorRepositorioReseva().MapearT1T2(listadoReservaBD).ToList();
                return lista;
            }
        }

        public bool EliminarReserva(int id)
        {
            throw new NotImplementedException();
        }

        public bool RegistrarReserva(ReservaDBModel reserva)
        {
            try
            {
                reserva Reserva1 = new MapeadorRepositorioReseva().MapearT2T1(reserva);
                using(petServicesEntities1 db = new petServicesEntities1())
                {
                    db.reservas.Add(Reserva1);
                    db.SaveChanges();
                    return true;
                }

            }
            catch
            {
                return false;
            }
        }
    }
}
