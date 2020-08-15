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
    }
}