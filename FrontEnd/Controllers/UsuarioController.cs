using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;

namespace FrontEnd.Controllers
{
    public class UsuarioController : Controller
    {

        private UsuarioViewModel Convertir(Usuario usuario)
        {
            return new UsuarioViewModel
            {

                 id      = usuario.id,
                 estado  = usuario.estado
                 /*
                 usuario 
                 salt 
                 clave 
                 tipo 
                 fecha_creacion 
                 ultimo_login 
                 string identificacion 
                 string nombre 
                 string email1 
                 string email2 
                 string telefono1 
                 string telefono2 
                 int pais 
                 int provincia 
                 int canton 
                 int distrito 
                 string direccion 
                 */

              };

        }

        // GET: Usuario
        public ActionResult Index()
        {


            List<Usuario> usuarios;
            using (UnidadDeTrabajo<Usuario> Unidad = new UnidadDeTrabajo<Usuario>(new BDContext()))
            {
                usuarios = Unidad.genericDAL.GetAll().ToList();
            }
            List<UsuarioViewModel> UsuariosVM = new List<UsuarioViewModel>();


            UsuarioViewModel UsuarioViewModel;
            foreach (var item in usuarios)
            {
                UsuarioViewModel = this.Convertir(item);

                UsuariosVM.Add(UsuarioViewModel);

            }

            return View(UsuariosVM);
        }


        /*
         *************************************************************************************************************************** 
         *************************************************************************************************************************** 
         *************************************************************************************************************************** 
         ***************************************************************************************************************************  
         ***************************************************************************************************************************
         */

        // GET: Create
        public ActionResult Create()
        {

            UsuarioViewModel Usuario = new UsuarioViewModel { };

            /*
            //Traer Información de Finca
            using (UnidadDeTrabajo<Finca> unidad = new UnidadDeTrabajo<Finca>(new BDContext()))
            {
                propietario.Finca = unidad.genericDAL.GetAll().ToList();
            }
            */

            /*
            //Traer Información de Persona
            using (UnidadDeTrabajo<Persona> unidad = new UnidadDeTrabajo<Persona>(new BDContext()))
            {
                propietario.Persona = unidad.genericDAL.GetAll().ToList();
            }
            */

            return View(Usuario);
        }

        /*
        [HttpPost]
        public ActionResult Create(Propietario propietario)
        {

            //Serializar el arreglo POST
            NameValueCollection nvc = Request.Form;

            //Actualizar porcentage. 

            IPropietarioDAL propietarioDB = new PropietariosDALImpl();

            int p = propietarioDB.Actualizar_Porcentage(propietario.FincaId, 1);

            propietario.Porcentaje = p;

            using (UnidadDeTrabajo<Propietario> unidad = new UnidadDeTrabajo<Propietario>(new BDContext()))
            {
                unidad.genericDAL.Add(propietario);
                unidad.Complete();
            }


            return RedirectToAction("Index");
        }
        */


    }
}