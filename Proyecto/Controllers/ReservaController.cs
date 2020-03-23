using ContratosControladorApp1.Contratos;
using ContratosControladorApp1.DTO;
using Proyecto.Mapeadores;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class ReservaController: Controller
    {
        IReservaApp _controlador;
        public ReservaController(IReservaApp app)
        {
            _controlador = app;

        }

        public ActionResult Index()
        {
            MapeadorUIReserva mapeador = new MapeadorUIReserva();
            IEnumerable<ReservaDTO> ListaReservaDTO = _controlador.ConsultaReserva();
            IEnumerable<ReservaModel> model = mapeador.MapearT1T2(ListaReservaDTO);
            return View(model);
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
                        return RedirectToAction("Index");
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