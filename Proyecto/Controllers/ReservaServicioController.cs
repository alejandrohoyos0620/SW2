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
    public class ReservaServicioController : Controller

    {
        IReservaServicioApp _controlador;
        public ReservaServicioController(IReservaServicioApp app)
        {
            _controlador = app;

        }

        public ActionResult Index()
        {
            MapeadorUIReservaServicio mapeador = new MapeadorUIReservaServicio();
            IEnumerable<ReservaServicioDTO> ListaReservaServicioDTO = _controlador.ConsultaReservaServicios();
            IEnumerable<ReservaServicioModel> model = mapeador.MapearT1T2(ListaReservaServicioDTO);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(ReservaServicioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MapeadorUIReservaServicio mapeador = new MapeadorUIReservaServicio();
                    ReservaServicioDTO dto = mapeador.MapearT2T1(model);
                    bool guardado = _controlador.RegistrarReservaServicio(dto);
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