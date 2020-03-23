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
    public class MascotaController :Controller
    {
        IMascotaApp _controlador;
        public MascotaController(IMascotaApp app)
        {
            _controlador = app;

        }

        public ActionResult Index()
        {
            MapeadorUIMascota mapeador = new MapeadorUIMascota();
            IEnumerable<MascotaDTO> ListaMascotaDTO = _controlador.ConsultaMascotas();
            IEnumerable<MascotaModel> model = mapeador.MapearT1T2(ListaMascotaDTO);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(MascotaModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MapeadorUIMascota mapeador = new MapeadorUIMascota();
                    MascotaDTO dto = mapeador.MapearT2T1(model);
                    bool guardado = _controlador.RegistrarMascota(dto);
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