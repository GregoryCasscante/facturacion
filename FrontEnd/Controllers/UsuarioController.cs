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
        private BDContext context;

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
                fecha_creacion = usuario.fecha_creacion,
                ultimo_login = usuario.ultimo_login,
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


            //Traer Secundaria
            using (UnidadDeTrabajo<Pais> unidad = new UnidadDeTrabajo<Pais>(new BDContext()))
            {
                Usuario.Paises = unidad.genericDAL.GetAll().ToList();
            }
            using (UnidadDeTrabajo<Provincia> unidad = new UnidadDeTrabajo<Provincia>(new BDContext()))
            {
                Usuario.Provincias = unidad.genericDAL.GetAll().ToList();
            }
            using (UnidadDeTrabajo<Canton> unidad = new UnidadDeTrabajo<Canton>(new BDContext()))
            {
                Usuario.Cantones = unidad.genericDAL.GetAll().ToList();
            }
            using (UnidadDeTrabajo<Distrito> unidad = new UnidadDeTrabajo<Distrito>(new BDContext()))
            {
                Usuario.Distritos = unidad.genericDAL.GetAll().ToList();
            }



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

            using (context = new BDContext())
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

            using (context = new BDContext())
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

            using (context = new BDContext())
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