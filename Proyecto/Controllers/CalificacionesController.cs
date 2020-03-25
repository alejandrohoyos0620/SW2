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
    public class CalificacionesController:Controller
    {
        ICalificacionApp _controlador;
        public CalificacionesController(ICalificacionApp app)
        {
            _controlador = app;

        }

        public ActionResult Index(String nombre)
        {
            MapeadorUICalificaciones mapeador = new MapeadorUICalificaciones();
            IEnumerable<CalificacionesDTO> ListaCalificacionDTO = _controlador.ConsultaCalificaciones();
            IEnumerable<CalificacionesModel> model = mapeador.MapearT1T2(ListaCalificacionDTO);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(CalificacionesModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MapeadorUICalificaciones mapeador = new MapeadorUICalificaciones();
                    CalificacionesDTO dto = mapeador.MapearT2T1(model);
                    bool guardado = _controlador.RegistrarCalificacion(dto);
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