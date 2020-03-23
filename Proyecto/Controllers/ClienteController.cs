using ContratosControladorApp1.Contratos;
using ContratosControladorApp1.DTO;
using Proyecto.Mapeadores;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class ClienteController : Controller
    {
        IClienteApp _controlador;
        public ClienteController(IClienteApp app)
        {
            this._controlador = app;
            
        }

        public ActionResult Index()
        {
            MapeadorUICliente mapeador = new MapeadorUICliente();
            IEnumerable<ClienteDTO> ListaClienteDTO = _controlador.ConsultaClietes();            
            IEnumerable<ClienteModel> model = mapeador.MapearT1T2(ListaClienteDTO);            
           return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(ClienteModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MapeadorUICliente mapeador = new MapeadorUICliente();
                    ClienteDTO dto = mapeador.MapearT2T1(model);
                    bool guardado = _controlador.IngresarCliente(dto);
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