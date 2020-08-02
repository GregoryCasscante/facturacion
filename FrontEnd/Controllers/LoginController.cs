using BackEnd.DAL;
using BackEnd.Entities;
using BackEnd.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class LoginController : Controller
    {
        // Instanciar la Clase de Autentificacion 
        private Auth Autentificacion = new Auth();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // POST
        [HttpPost]
        public ActionResult Auth()
        {
            var CMD         = Request["CMD"];
            var cod_usuario = Request["cod_usuario"];
            var clave       = Request["clave"];

            if (String.IsNullOrEmpty(cod_usuario) || String.IsNullOrEmpty(clave))
            {
                Response.Redirect("/login?error=Usuario_Clave_Invalido");
            }

            if (Autentificacion.Login(cod_usuario, clave))
            {
                /*
                var user = db.usuarios.Where(b => b.cod_usuario == cod_usuario).FirstOrDefault();

                Session["user.cod_usuario"] = user.cod_usuario;
                Session["user.nombre"] = user.cod_usuario;
                Session["user.email"] = user.email;
                Session["user.tipo_usuario"] = user.tipo_usuario;
                Session["user.indica_activo"] = user.indica_activo;

                //Variable de Autentificacion
                Session["Autentificado"] = "Yes";


                //Guardar IP y fecha de cada Login
                var ClientIP = Autentificacion.GetIPAddress();

                User_Logins Login_data = new User_Logins();
                Login_data.usuario = user.cod_usuario;
                Login_data.tdate = DateTime.Now.ToString();
                Login_data.ip = ClientIP;

                db.User_Logins.Add(Login_data);
                db.SaveChanges();

                Response.Redirect("/Home/index");
                */
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