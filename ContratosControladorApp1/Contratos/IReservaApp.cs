using ContratosControladorApp1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratosControladorApp1.Contratos
{
    public interface IReservaApp
    {
        bool RegistrarReserva(ReservaDTO reserva);
        Boolean BuscarReserva(DateTime fecha, TimeSpan hora);
        bool EliminarReserva(int id);
        bool ActualizarReserva(ReservaDTO reserva);
        IEnumerable<ReservaDTO> ConsultaReserva();
    }
}
