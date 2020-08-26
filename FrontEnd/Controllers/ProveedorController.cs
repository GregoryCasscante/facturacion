using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackEnd.Entities;
using BackEnd.DAL;
using FrontEnd.Models;

namespace FrontEnd.Controllers
{
    public class ProveedorController : MyBaseController
    {
        // GET: Proveedor
        private ProveedorViewModel Convertir(Proveedor proveedor)
        {
            ProveedorViewModel proveedorViewModel = new ProveedorViewModel
            {

                id = proveedor.id,
                id_compania = proveedor.id_compania,
                nombre_comercial = proveedor.nombre_comercial,
                dni = proveedor.dni,
                tipo_dni = proveedor.tipo_dni,
                actividad_economica = proveedor.actividad_economica,
                email1 = proveedor.email1,
                email2 = proveedor.email2,
                telefono1 = proveedor.telefono1,
                telefono2 = proveedor.telefono2,
                pais = proveedor.pais,
                provincia = proveedor.provincia,
                canton = proveedor.canton,
                distrito = proveedor.distrito,
                direccion = proveedor.direccion

            };
            return proveedorViewModel;
        }



        private Proveedor Convertir(ProveedorViewModel proveedorViewModel)
        {
            Proveedor proveedor = new Proveedor
            {
                id = proveedorViewModel.id,
                id_compania = proveedorViewModel.id_compania,
                nombre_comercial = proveedorViewModel.nombre_comercial,
                dni = proveedorViewModel.dni,
                tipo_dni = proveedorViewModel.tipo_dni,
                actividad_economica = proveedorViewModel.actividad_economica,
                email1 = proveedorViewModel.email1,
                email2 = proveedorViewModel.email2,
                telefono1 = proveedorViewModel.telefono1,
                telefono2 = proveedorViewModel.telefono2,
                pais = proveedorViewModel.pais,
                provincia = proveedorViewModel.provincia,
                canton = proveedorViewModel.canton,
                distrito = proveedorViewModel.distrito,
                direccion = proveedorViewModel.direccion

            };
            return proveedor;
        }

        // GET: Proveedor
        public ActionResult Index()
        {
            List<Proveedor> proveedors;
            using (UnidadDeTrabajo<Proveedor> Unidad = new UnidadDeTrabajo<Proveedor>(new DBContext()))
            {
                proveedors = Unidad.genericDAL.GetAll().ToList();
            }

            List<ProveedorViewModel> lista = new List<ProveedorViewModel>();

            foreach (var item in proveedors)
            {
                lista.Add(this.Convertir(item));
            }

            return View(lista);
        }

        public ActionResult Create()
        {
            ProveedorViewModel proveedor = new ProveedorViewModel { };

            using (UnidadDeTrabajo<Actividades_Economica> unidad = new UnidadDeTrabajo<Actividades_Economica>(new DBContext()))
            {
                proveedor.actividades_economicas = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Compania> unidad = new UnidadDeTrabajo<Compania>(new DBContext()))
            {
                proveedor.companias = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Pais> unidad = new UnidadDeTrabajo<Pais>(new DBContext()))
            {
                proveedor.paises = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Provincia> unidad = new UnidadDeTrabajo<Provincia>(new DBContext()))
            {
                proveedor.provincias = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Canton> unidad = new UnidadDeTrabajo<Canton>(new DBContext()))
            {
                proveedor.cantones = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Distrito> unidad = new UnidadDeTrabajo<Distrito>(new DBContext()))
            {
                proveedor.distritos = unidad.genericDAL.GetAll().ToList();
            }

            return View(proveedor);
        }

        [HttpPost]
        public ActionResult Create(ProveedorViewModel proveedorViewModel)
        {
            Proveedor proveedor = this.Convertir(proveedorViewModel);

            using (UnidadDeTrabajo<Proveedor> unidad = new UnidadDeTrabajo<Proveedor>(new DBContext()))
            {
                unidad.genericDAL.Add(proveedor);
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }



        public ActionResult Edit(int id)
        {

            Proveedor proveedor;

            using (UnidadDeTrabajo<Proveedor> unidad = new UnidadDeTrabajo<Proveedor>(new DBContext()))
            {
                proveedor = unidad.genericDAL.Get(id);

            }

            ProveedorViewModel proveedorVM = this.Convertir(proveedor);

            using (UnidadDeTrabajo<Actividades_Economica> unidad = new UnidadDeTrabajo<Actividades_Economica>(new DBContext()))
            {
                proveedorVM.actividades_economicas = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Compania> unidad = new UnidadDeTrabajo<Compania>(new DBContext()))
            {
                proveedorVM.companias = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Pais> unidad = new UnidadDeTrabajo<Pais>(new DBContext()))
            {
                proveedorVM.paises = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Provincia> unidad = new UnidadDeTrabajo<Provincia>(new DBContext()))
            {
                proveedorVM.provincias = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Canton> unidad = new UnidadDeTrabajo<Canton>(new DBContext()))
            {
                proveedorVM.cantones = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Distrito> unidad = new UnidadDeTrabajo<Distrito>(new DBContext()))
            {
                proveedorVM.distritos = unidad.genericDAL.GetAll().ToList();
            }

            return View(proveedorVM);

        }


        [HttpPost]
        public ActionResult Edit(ProveedorViewModel proveedorViewModel)
        {


            using (UnidadDeTrabajo<Proveedor> unidad = new UnidadDeTrabajo<Proveedor>(new DBContext()))
            {
                unidad.genericDAL.Update(this.Convertir(proveedorViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {

            Proveedor proveedor;
            using (UnidadDeTrabajo<Proveedor> unidad = new UnidadDeTrabajo<Proveedor>(new DBContext()))
            {
                proveedor = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(proveedor));
        }

        public ActionResult Delete(int id)
        {

            Proveedor proveedor;
            using (UnidadDeTrabajo<Proveedor> unidad = new UnidadDeTrabajo<Proveedor>(new DBContext()))
            {
                proveedor = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(proveedor));
        }

        [HttpPost]
        public ActionResult Delete(ProveedorViewModel proveedorViewModel)
        {
            using (UnidadDeTrabajo<Proveedor> unidad = new UnidadDeTrabajo<Proveedor>(new DBContext()))
            {
                unidad.genericDAL.Remove(this.Convertir(proveedorViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}