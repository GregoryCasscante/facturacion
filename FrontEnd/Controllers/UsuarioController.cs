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

                 id = usuario.id
                 /*
                 estado 
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
            return View();
        }
    }
}