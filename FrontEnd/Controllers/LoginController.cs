using BackEnd.DAL;
using BackEnd.Entities;
using BackEnd.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class LoginController : Controller
    {
        // Instanciar la Clase de Autentificacion 
        private Auth Autentificacion               = new Auth();
        private IUsuarioDAL usuarioDAL             = new UsuarioDALImpl();
        private IUsuario_LoginDAL usuario_loginDAL = new Usuario_LoginDALImpl();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // POST
        [HttpPost]
        public ActionResult Auth()
        {

            //For Testing
            Thread.Sleep(1000);

            var CMD         = Request["CMD"];
            var cod_usuario = Request["cod_usuario"];
            var clave       = Request["clave"];

            if (String.IsNullOrEmpty(cod_usuario) || String.IsNullOrEmpty(clave))
            {
                Response.Redirect("/login?error=Usuario_Clave_Invalido");
            }


            if (Autentificacion.Login(cod_usuario, clave))
            {
                Usuario usuario = usuarioDAL.Get(cod_usuario);

                Session["user.id"]      = usuario.id;
                Session["user.usuario"] = usuario.usuario;
                Session["user.tipo"]    = usuario.tipo;
                Session["user.email1"]  = usuario.email1;
                

                //Variable de Autentificacion
                Session["Autentificado"] = "Yes";

                
                //Guardar IP y fecha de cada Login
                var ClientIP = Autentificacion.GetIPAddress();

                Usuario_Login usuario_Login = new Usuario_Login()
                {
                    usuario = usuario.id,
                    nombre  = usuario.usuario,
                    ip      = ClientIP,
                    fecha   = DateTime.Now
                };

                //Crear el log de Login
                usuario_loginDAL.Add(usuario_Login);

                Response.Redirect("/Home/index");
             
            }
            else
            {
                Response.Redirect("/login?error=Usuario_Clave_Invalido");
                Session["Autentificado"] = "No";
                Session["UltimoAcceso"] = "";
            }

            //Regresar View Pero no es necesario. 
            return View("Index");

        }

        // GET: Logout
        public ActionResult Logout()
        {

            Session["Autentificado"] = "No";
            Session["UltimoAcceso"] = "";


            Session["user.cod_usuario"] = "";
            Session["user.nombre"] = "";
            Session["user.email"] = "";
            Session["user.tipo_usuario"] = "";
            Session["user.indica_activo"] = "";

            Response.Redirect("/login?Logout=yes");

            return View();
        }


    }
}