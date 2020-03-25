using ContratosControladorApp1.Contratos;
using ContratosControladorApp1.DTO;
using Proyecto.Mapeadores;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace Proyecto.Controllers
{
    public class ReservaController : Controller
    {
        IReservaApp _controlador;
        public ReservaController(IReservaApp app)
        {
            _controlador = app;

        }

        public ActionResult Index()
        {
            MapeadorUIReserva mapeadorReserv = new MapeadorUIReserva();
            IEnumerable<ReservaDTO> ListaReservaDTO = _controlador.ConsultaReserva();
            IEnumerable<ReservaModel> model = mapeadorReserv.MapearT1T2(ListaReservaDTO);
            return View(model);
        }

        [HttpPost]
        public ActionResult Buscar(DateTime fecha, TimeSpan hora)
        {

            Boolean Validacion = _controlador.BuscarReserva(fecha, hora);
            if (Validacion)
            {

                Create(
                   new ReservaModel()
                   {
                       Id_cliente = 1,
                       Id_reservacion = 2,
                       fecha = fecha,
                       hora = hora,
                       Total = 40000,
                       Estadoreserva = "h",
                       Tipopago = "Tarjeta",
                       Factura = "1"
                   }
                    );

                Response.Write("<script languaje=javascript>alert('¡La reserva ha sido registrada exitosamente');</script>");
                return Redirect("../Servicio/Index");
            }
            else
            {
                Response.Write("<script languaje=javascript>alert('¡La reserva a la hora indicada no se encuentra disponible! Porfavor selecciones otra hora');</script>");
                return View("Index");
            }
        }
        public ActionResult Buscar()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(ReservaModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MapeadorUIReserva mapeador = new MapeadorUIReserva();
                    ReservaDTO dto = mapeador.MapearT2T1(model);
                    bool guardado = _controlador.RegistrarReserva(dto);
                    if (guardado)
                    {
                        return RedirectToAction("../Home/Index");
                    }
                    else
                    {
                        return View(model);
                    }
                }
                else
                {
                    return View(model);
                }
            }
            catch
            {
                return View();
            }
        }
    }
}