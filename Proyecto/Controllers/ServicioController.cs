using ContratosControladorApp1.Contratos;
using ContratosControladorApp1.DTO;
using Proyecto.Mapeadores;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class ServicioController:Controller
    {
        IServicioApp _controlador;
        public ServicioController(IServicioApp app)
        {
            _controlador = app;

        }
        public ActionResult Index()
        {
            MapeadorUIServicio mapeador = new MapeadorUIServicio();
            IEnumerable<ServicioDTO> ListaServicioDTO = _controlador.ConsultaServicios();
            IEnumerable<ServicioModel> model = mapeador.MapearT1T2(ListaServicioDTO);
            return View(model);
        }
        public ActionResult Detalle(int id)
        {
            MapeadorUIServicio mapeador = new MapeadorUIServicio();
            ServicioDTO dto = _controlador.BuscarServicio(id);
            ServicioModel modelo = mapeador.MapearT1T2(dto);
            return View(modelo);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ServicioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MapeadorUIServicio mapeador = new MapeadorUIServicio();
                    ServicioDTO dto = mapeador.MapearT2T1(model);
                    bool guardado = _controlador.RegistrarServicio(dto);
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