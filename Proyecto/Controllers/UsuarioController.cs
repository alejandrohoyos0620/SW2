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
    public class UsuarioController : Controller
    {
        IUsuarioApp _controlador;
        public UsuarioController(IUsuarioApp app)
        {
           _controlador = app;

        }

        public ActionResult Index()
        {
            MapeadorUIUsuario mapeador = new MapeadorUIUsuario();
            IEnumerable<UsuarioDTO> ListaUsuarioDTO = _controlador.ConsultaUsuarios();
            IEnumerable<UsuarioModel> model = mapeador.MapearT1T2(ListaUsuarioDTO);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(UsuarioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MapeadorUIUsuario mapeador = new MapeadorUIUsuario();
                    UsuarioDTO dto = mapeador.MapearT2T1(model);
                    bool guardado = _controlador.IngresarUsuario(dto);
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