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
using System.Web.Security;

namespace Proyecto.Controllers
{
    public class UsuarioController : Controller
    {
        IUsuarioApp _controlador;
        public UsuarioController(IUsuarioApp app)
        {
            _controlador = app;

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
                    if (model.Contraseña2.Equals(model.Contraseña))
                    {
                        UsuarioModel model2 = new UsuarioModel()
                        {
                            Id_usuario = model.Id_usuario,
                            Nombre = model.Nombre,
                            Contraseña = model.Contraseña
                        };
                        MapeadorUIUsuario mapeador = new MapeadorUIUsuario();
                        UsuarioDTO dto = mapeador.MapearT2T1(model2);
                        bool guardado = _controlador.IngresarUsuario(dto);
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



        public ActionResult Ingresar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ingresar(UsuarioModel user)
        {

            if (IsValid(user.Nombre, user.Contraseña).Equals(""))
            {
                ModelState.AddModelError("", "Inicio de sesión incorrecta.");
                Debug.WriteLine("Inicio de sesión incorrecta");

            }
            else
            {
                FormsAuthentication.SetAuthCookie(user.Nombre, false);
                Debug.WriteLine("Inicio de sesión");
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Salir()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }



        private string IsValid(string nombre, string pass)
        {
            string isValid = _controlador.IsValid(nombre, pass);
            return isValid;
        }

    }
}