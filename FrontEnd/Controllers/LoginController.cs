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
        // GET: Login
        public ActionResult Index()
        {

            IUsuarioDAL usuarioDAL = new UsuarioDALImpl();

            //Crear salted password
            Auth auth = new Auth();
            string salt = auth.generarSalt();
            Console.WriteLine("Salt:" + auth.generarSalt());
            string clave = auth.hash_password("12345678", salt);
            Console.WriteLine("Hashed Password :" + clave);


            Usuario usuario = new Usuario()
            {
                estado     = 1,
                usuario    = "gcascante",
                salt       = salt,
                clave      = clave,
                tipo       = 1,
                fecha_creacion = DateTime.Now,
                ultimo_login = DateTime.Now,
                identificacion = "112560518",
                nombre = "Gregory Cascante Aviles",
                email1 = "gregory@santafe.co.cr",
                email2 = "gregory@santafe.co.cr",
                telefono1 = "88493551",
                telefono2 = "88493551",
                pais = 53,
                provincia = 1,
                canton = 101,
                distrito = 10201,
                direccion = "Escazu"                   

            };

            usuarioDAL.Add(usuario);










            return View();
        }
    }
}