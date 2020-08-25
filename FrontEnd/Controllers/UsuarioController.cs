using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackEnd.DAL;
using BackEnd.Entities;
using BackEnd.Libraries;
using FrontEnd.Models;

namespace FrontEnd.Controllers
{
    public class UsuarioController : MyBaseController
    {

        //Inicialización de Clases y Variables
        private DBContext context;
        private Auth Autentificacion   = new Auth();
        private IUsuarioDAL usuarioDAL = new UsuarioDALImpl();

        private UsuarioViewModel Convertir(Usuario usuario)
        {
            return new UsuarioViewModel
            {

                id = usuario.id,
                estado = usuario.estado,
                usuario = usuario.usuario,
                salt = usuario.salt,
                clave = usuario.clave,
                tipo = usuario.tipo,
                fecha_creacion = DateTime.Now,
                ultimo_login   = usuario.ultimo_login,
                identificacion = usuario.identificacion,
                nombre = usuario.nombre,
                email1 = usuario.email1,
                email2 = usuario.email2,
                telefono1 = usuario.telefono1,
                telefono2 = usuario.telefono2,
                pais = usuario.pais,
                provincia = usuario.provincia,
                canton = usuario.canton,
                distrito = usuario.distrito,
                direccion = usuario.direccion

            };

        }

        // GET: Usuario
        public ActionResult Index()
        {


            List<Usuario> usuarios;
            using (UnidadDeTrabajo<Usuario> Unidad = new UnidadDeTrabajo<Usuario>(new DBContext()))
            {
                usuarios = Unidad.genericDAL.GetAll().ToList();
            }
            List<UsuarioViewModel> UsuariosVM = new List<UsuarioViewModel>();


            UsuarioViewModel UsuarioViewModel;
            foreach (var item in usuarios)
            {
                UsuarioViewModel = this.Convertir(item);

                //Traer Datos Secundarios
                using (UnidadDeTrabajo<Pais> unidad = new UnidadDeTrabajo<Pais>(new DBContext()))
                {
                    UsuarioViewModel.UsuarioPais = unidad.genericDAL.Get(Convert.ToInt32(item.pais));
                }
                using (UnidadDeTrabajo<Provincia> unidad = new UnidadDeTrabajo<Provincia>(new DBContext()))
                {
                    UsuarioViewModel.UsuarioProvincia = unidad.genericDAL.Get(Convert.ToInt32(item.provincia));
                }

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


            //Traer Datos Secundarios
            using (UnidadDeTrabajo<Pais> unidad = new UnidadDeTrabajo<Pais>(new DBContext()))
            {
                Usuario.Paises = unidad.genericDAL.GetAll().ToList();
            }
            using (UnidadDeTrabajo<Provincia> unidad = new UnidadDeTrabajo<Provincia>(new DBContext()))
            {
                Usuario.Provincias = unidad.genericDAL.GetAll().ToList();
            }
            using (UnidadDeTrabajo<Canton> unidad = new UnidadDeTrabajo<Canton>(new DBContext()))
            {
                Usuario.Cantones = unidad.genericDAL.GetAll().ToList();
            }
            using (UnidadDeTrabajo<Distrito> unidad = new UnidadDeTrabajo<Distrito>(new DBContext()))
            {
                Usuario.Distritos = unidad.genericDAL.GetAll().ToList();
            }



            return View(Usuario);
        }

        /*
         *************************************************************************************************************************** 
         *************************************************************************************************************************** 
         *************************************************************************************************************************** 
         ***************************************************************************************************************************  
         ***************************************************************************************************************************
         */

        [HttpPost]
        public ActionResult Create(Usuario u)
        {

            //Serializar el arreglo POST
            NameValueCollection r = Request.Form;
            
            Usuario usuario = new Usuario {

                estado         = Convert.ToInt32(Request["estado"]),
                usuario        = Request["usuario"],
                clave          = Request["clave"],
                tipo           = 1,
                fecha_creacion = DateTime.Now,
                ultimo_login   = null,
                identificacion = Request["identificacion"],
                nombre         = Request["nombre"],
                email1         = Request["email1"],
                email2         = Request["email1"],
                telefono1      = Request["telefono1"],
                telefono2      = "",
                pais           = Convert.ToInt32(Request["pais"]),
                provincia      = Convert.ToInt32(Request["provincia"]),
                canton         = Convert.ToInt32(Request["canton"]),
                distrito       = Convert.ToInt32(Request["distrito"]),
                direccion      = Request["direccion"]

            };
           

            IUsuarioDAL usuarioDB = new UsuarioDALImpl();

            Auth auth    = new Auth();
            usuario.salt = auth.generarSalt();
            usuario.clave = auth.hash_password(usuario.clave, usuario.salt);

            using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(new DBContext()))
            {
                unidad.genericDAL.Add(usuario);
                unidad.Complete();
            }

            //usuarioDB.Create(usuario);

            return RedirectToAction("Index");
        }



        /*
         *************************************************************************************************************************** 
         *************************************************************************************************************************** 
         *************************************************************************************************************************** 
         ***************************************************************************************************************************  
         ***************************************************************************************************************************
         */
        public ActionResult Edit(int id)
        {
            Usuario usuarioEntity;  //Objeto de BackEnd
            using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(new DBContext()))
            {
                usuarioEntity = unidad.genericDAL.Get(id);
            }

            UsuarioViewModel usuario = this.Convertir(usuarioEntity);

            //Traer Datos Secundarios
            using (UnidadDeTrabajo<Pais> unidad = new UnidadDeTrabajo<Pais>(new DBContext()))
            {
                usuario.Paises = unidad.genericDAL.GetAll().ToList();
            }
            using (UnidadDeTrabajo<Provincia> unidad = new UnidadDeTrabajo<Provincia>(new DBContext()))
            {
                usuario.Provincias = unidad.genericDAL.GetAll().ToList();
            }
            using (UnidadDeTrabajo<Canton> unidad = new UnidadDeTrabajo<Canton>(new DBContext()))
            {
                usuario.Cantones = unidad.genericDAL.GetAll().ToList();
            }
            using (UnidadDeTrabajo<Distrito> unidad = new UnidadDeTrabajo<Distrito>(new DBContext()))
            {
                usuario.Distritos = unidad.genericDAL.GetAll().ToList();
            }

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Edit(Usuario u)
        {

            //Serializar el arreglo POST
            NameValueCollection r = Request.Form;
            Usuario usuario = u;
            /*
            Usuario usuario = new Usuario
            {

                id              = Convert.ToInt32(Request["id"]),
                estado          = Convert.ToInt32(Request["estado"]),
                usuario         = Request["usuario"],
                salt            = Request["salt"],
                clave           = Request["clave"],
                tipo            = 1,
                fecha_creacion  = Convert.ToDateTime(Request["fecha_creacion"]),
                ultimo_login    = Convert.ToDateTime(Request["ultimo_login"]),
                identificacion  = Request["identificacion"],
                nombre          = Request["nombre"],
                email1          = Request["email1"],
                email2          = Request["email2"],
                telefono1       = Request["telefono1"],
                telefono2       = Request["telefono2"],
                pais            = Convert.ToInt32(Request["pais"]),
                provincia       = Convert.ToInt32(Request["provincia"]),
                canton          = Convert.ToInt32(Request["canton"]),
                distrito        = Convert.ToInt32(Request["distrito"]),
                direccion       = Request["direccion"]

            };
            */

            using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(new DBContext()))
            {


                Usuario usuario_temp;
                usuario_temp = unidad.genericDAL.Get(usuario.id);

                if (usuario.clave != "--------")
                {
                    //Update the Password. 
                    Auth auth = new Auth();
                    usuario.clave = auth.hash_password(usuario.clave, usuario_temp.salt);
                } else
                {
                    usuario.clave = usuario_temp.clave;
                }



                unidad.genericDAL.Update(usuario);
                unidad.Complete();


                IUsuarioDAL usuarioDB = new UsuarioDALImpl();
                usuarioDB.Update(usuario);
            }

            return RedirectToAction("Index");
        }

        /*
         *************************************************************************************************************************** 
         *************************************************************************************************************************** 
         *************************************************************************************************************************** 
         ***************************************************************************************************************************  
         ***************************************************************************************************************************
         */
        public ActionResult Details(int? id)
        {
            //Serializar el POST form. 
            string id_value = id.ToString();

            //Antes de hacer el query revisar por la variable int, que no sea null 
            //Esto para reviasr errores. 
            if (String.IsNullOrEmpty(id_value))
            {

                //Regresar al Index ya que no hay valores
                return RedirectToAction("Index");

            }
            else
            {
                Usuario usuarioEntity;
                using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(new DBContext()))
                {
                    usuarioEntity = unidad.genericDAL.Get((int)id);
                }

                UsuarioViewModel usuarioVM = this.Convertir(usuarioEntity);

                //Traer Datos Secundarios
                using (UnidadDeTrabajo<Pais> unidad = new UnidadDeTrabajo<Pais>(new DBContext()))
                {
                    usuarioVM.UsuarioPais = unidad.genericDAL.Get(Convert.ToInt32(usuarioEntity.pais));
                }
                using (UnidadDeTrabajo<Provincia> unidad = new UnidadDeTrabajo<Provincia>(new DBContext()))
                {
                    usuarioVM.UsuarioProvincia = unidad.genericDAL.Get(Convert.ToInt32(usuarioEntity.provincia));
                }
                IUsuarioDAL usuarioDB = new UsuarioDALImpl();
                usuarioVM.UsuarioCanton = usuarioDB.GetCanton(Convert.ToInt32(usuarioEntity.canton));

                using (UnidadDeTrabajo<Distrito> unidad = new UnidadDeTrabajo<Distrito>(new DBContext()))
                {
                    usuarioVM.UsuarioDistrito = unidad.genericDAL.Get(Convert.ToInt32(usuarioEntity.distrito));
                }

                ViewBag.u = usuarioVM;

                return View(usuarioVM);

            }
        }


        /*
         *************************************************************************************************************************** 
         *************************************************************************************************************************** 
         *************************************************************************************************************************** 
         ***************************************************************************************************************************  
         ***************************************************************************************************************************
         */
        public ActionResult Delete(int? id)
        {
            //Serializar el POST form. 
            string id_value = id.ToString();

            //Antes de hacer el query revisar por la variable int, que no sea null 
            //Esto para reviasr errores. 
            if (String.IsNullOrEmpty(id_value))
            {

                //Regresar al Index ya que no hay valores
                return RedirectToAction("Index");

            }
            else
            {
                Usuario usuarioEntity;
                using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(new DBContext()))
                {
                    usuarioEntity = unidad.genericDAL.Get((int)id);
                }

                UsuarioViewModel usuarioVM = this.Convertir(usuarioEntity);

                //Traer Datos Secundarios
                using (UnidadDeTrabajo<Pais> unidad = new UnidadDeTrabajo<Pais>(new DBContext()))
                {
                    usuarioVM.UsuarioPais = unidad.genericDAL.Get(Convert.ToInt32(usuarioEntity.pais));
                }
                using (UnidadDeTrabajo<Provincia> unidad = new UnidadDeTrabajo<Provincia>(new DBContext()))
                {
                    usuarioVM.UsuarioProvincia = unidad.genericDAL.Get(Convert.ToInt32(usuarioEntity.provincia));
                }
                IUsuarioDAL usuarioDB = new UsuarioDALImpl();
                usuarioVM.UsuarioCanton = usuarioDB.GetCanton(Convert.ToInt32(usuarioEntity.canton));

                using (UnidadDeTrabajo<Distrito> unidad = new UnidadDeTrabajo<Distrito>(new DBContext()))
                {
                    usuarioVM.UsuarioDistrito = unidad.genericDAL.Get(Convert.ToInt32(usuarioEntity.distrito));
                }

                ViewBag.u = usuarioVM;

                return View(usuarioVM);

            }
        }



        [HttpPost]
        public ActionResult Delete(Usuario u)
        {

            //Serializar el arreglo POST
            NameValueCollection nvc = Request.Form;

            using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(new DBContext()))
            {
                unidad.genericDAL.Remove(u);
                unidad.Complete();
            }


            return RedirectToAction("Index");
        }


        /*
         *************************************************************************************************************************** 
         *************************************************************************************************************************** 
         *************************************************************************************************************************** 
         ***************************************************************************************************************************  
         ***************************************************************************************************************************
         *************************************************************************************************************************** 
         *************************************************************************************************************************** 
         *************************************************************************************************************************** 
         ***************************************************************************************************************************  
         ***************************************************************************************************************************         
         */
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetProvincias(string pais)
        {
            if ( !pais.Equals("") )
            {
                var provincias = GetProvinciasList(Convert.ToInt32(pais));
                return Json(provincias, JsonRequestBehavior.AllowGet);
            } else  {
                var selectList = new List<SelectListItem>();
                return Json(selectList, JsonRequestBehavior.AllowGet);
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetCantones(string provincia)
        {
            var provincias = GetCantonesList(Convert.ToInt32(provincia));
            return Json(provincias, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetDistritos(string canton)
        {
            var distritos = GetDistritosList(Convert.ToInt32(canton));
            return Json(distritos, JsonRequestBehavior.AllowGet);
        }


        [NonAction]
        public IEnumerable<SelectListItem> GetProvinciasList(int pais)
        {
            //generate empty list
            var selectList = new List<SelectListItem>();

            using (context = new DBContext())
            {
                var provincias = from p in context.Provincias
                                 where p.pais == pais
                                 select p;

                foreach (var subcategory in provincias)
                {
                    //add elements in dropdown
                    selectList.Add(new SelectListItem
                    {
                        Value = subcategory.id.ToString(),
                        Text = subcategory.Nombre.ToString()
                    });
                }
            }


            return selectList;
        }


        [NonAction]
        public IEnumerable<SelectListItem> GetCantonesList(int provincia)
        {
            //generate empty list
            var selectList = new List<SelectListItem>();

            using (context = new DBContext())
            {
                var cantones = from c in context.Cantones
                               where c.provincia == provincia
                               select c;

                foreach (var subcategory in cantones)
                {
                    //add elements in dropdown
                    selectList.Add(new SelectListItem
                    {
                        Value = subcategory.canton.ToString(),
                        Text = subcategory.Nombre.ToString()
                    });
                }
            }


            return selectList;
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetDistritosList(int canton)
        {
            //generate empty list
            var selectList = new List<SelectListItem>();

            using (context = new DBContext())
            {
                var distritos = from d in context.Distritos
                                where d.canton == canton
                                select d;

                foreach (var subcategory in distritos)
                {
                    //add elements in dropdown
                    selectList.Add(new SelectListItem
                    {
                        Value = subcategory.canton.ToString(),
                        Text = subcategory.nombre.ToString()
                    });
                }
            }


            return selectList;
        }

        


        //End Public Classs
    }
}