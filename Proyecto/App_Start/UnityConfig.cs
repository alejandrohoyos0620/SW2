using AccesoDatos1.Implementacion;
using ContratoAccesoDatos1.Contratos;
using ContratosControladorApp1.Contratos;
using ControladorApp1.Implementacion;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Proyecto
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICliente,ClienteRepositorio>();
            container.RegisterType<IUsuario,UsuarioRepositorio>();
            container.RegisterType<IReserva,ReservaRepositorio>();
            container.RegisterType<IServicio,ServicioRepositorio>();
            container.RegisterType<IReservaServicios,ReservaServicioRepositorio>();
            container.RegisterType<IMascota,MascotaRepositorio>();
            container.RegisterType<ICalificaciones,CalificacionesRepositorio>();
            container.RegisterType<IClienteApp, ControladorCliente>();
            container.RegisterType<IUsuarioApp, ControladorUsuario>();
            container.RegisterType<IReservaApp, ControladorReserva>();
            container.RegisterType<IReservaServicioApp, ControladorReservaServicio>();
            container.RegisterType<IServicioApp, ControladorServicio>();
            container.RegisterType<IMascotaApp, ControladorMascota>();
            container.RegisterType<ICalificacionApp, ControladorCalificaciones>(); 
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}