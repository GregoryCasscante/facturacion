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
    public class MantenimientoController : MyBaseController
    {
        // GET: Mantenimiento
        private MantenimientoViewModel Convertir(Mantenimientos mantenimiento)
        {
            MantenimientoViewModel mantenimientoViewModel = new MantenimientoViewModel
            {

                id = mantenimiento.id,
                descripcion = mantenimiento.descripcion

            };
            return mantenimientoViewModel;
        }



        private Mantenimientos Convertir(MantenimientoViewModel mantenimientoViewModel)
        {
            Mantenimientos mantenimiento = new Mantenimientos
            {
                id = mantenimientoViewModel.id,
                descripcion = mantenimientoViewModel.descripcion

            };
            return mantenimiento;
        }

        // GET: Mantenimiento
        public ActionResult Index()
        {
            List<Mantenimientos> mantenimientos;

            using (UnidadDeTrabajo<Mantenimientos> Unidad = new UnidadDeTrabajo<Mantenimientos>(new DBContext()))
            {
                mantenimientos = Unidad.genericDAL.GetAll().ToList();
            }

            List<MantenimientoViewModel> lista = new List<MantenimientoViewModel>();

            foreach (var item in mantenimientos)
            {

                lista.Add(this.Convertir(item));
            }

            return View(lista);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(MantenimientoViewModel mantenimientoViewModel)
        {
            Mantenimientos mantenimiento = this.Convertir(mantenimientoViewModel);

            using (UnidadDeTrabajo<Mantenimientos> unidad = new UnidadDeTrabajo<Mantenimientos>(new DBContext()))
            {
                unidad.genericDAL.Add(mantenimiento);
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }



        public ActionResult Edit(int id)
        {

            Mantenimientos mantenimiento;

            using (UnidadDeTrabajo<Mantenimientos> unidad = new UnidadDeTrabajo<Mantenimientos>(new DBContext()))
            {
                mantenimiento = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(mantenimiento));
        }


        [HttpPost]
        public ActionResult Edit(MantenimientoViewModel mantenimientoViewModel)
        {


            using (UnidadDeTrabajo<Mantenimientos> unidad = new UnidadDeTrabajo<Mantenimientos>(new DBContext()))
            {
                unidad.genericDAL.Update(this.Convertir(mantenimientoViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {

            Mantenimientos mantenimiento;

            using (UnidadDeTrabajo<Mantenimientos> unidad = new UnidadDeTrabajo<Mantenimientos>(new DBContext()))
            {
                mantenimiento = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(mantenimiento));
        }

        public ActionResult Delete(int id)
        {

            Mantenimientos mantenimiento;

            using (UnidadDeTrabajo<Mantenimientos> unidad = new UnidadDeTrabajo<Mantenimientos>(new DBContext()))
            {
                mantenimiento = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(mantenimiento));
        }

        [HttpPost]
        public ActionResult Delete(MantenimientoViewModel mantenimientoViewModel)
        {
            using (UnidadDeTrabajo<Mantenimientos> unidad = new UnidadDeTrabajo<Mantenimientos>(new DBContext()))
            {
                unidad.genericDAL.Remove(this.Convertir(mantenimientoViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}