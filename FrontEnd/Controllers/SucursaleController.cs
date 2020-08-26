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
    public class SucursaleController : MyBaseController
    {
        // GET: Sucursal
        private SucursaleViewModel Convertir(Sucursal Sucursal)
        {
            SucursaleViewModel sucursaleViewModel = new SucursaleViewModel
            {

                id = Sucursal.id,
                compania = Sucursal.compania,
                nombre = Sucursal.nombre,
                dirrecion = Sucursal.dirrecion

            };
            return sucursaleViewModel;
        }



        private Sucursal Convertir(SucursaleViewModel sucursaleViewModel)
        {
            Sucursal Sucursal = new Sucursal
            {
                id = sucursaleViewModel.id,
                compania = sucursaleViewModel.compania,
                nombre = sucursaleViewModel.nombre,
                dirrecion = sucursaleViewModel.dirrecion

            };
            return Sucursal;
        }

        // GET: Sucursal

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Index()
        {
            List<Sucursal> sucursales;
            using (UnidadDeTrabajo<Sucursal> Unidad = new UnidadDeTrabajo<Sucursal>(new DBContext()))
            {
                sucursales = Unidad.genericDAL.GetAll().ToList();
            }

            List<SucursaleViewModel> lista = new List<SucursaleViewModel>();

            foreach (var item in sucursales)
            {
                lista.Add(this.Convertir(item));
            }

            return View(lista);
        }

        public ActionResult Create()
        {
            SucursaleViewModel Sucursal = new SucursaleViewModel { };

            using (UnidadDeTrabajo<Compania> unidad = new UnidadDeTrabajo<Compania>(new DBContext()))
            {
                Sucursal.companias = unidad.genericDAL.GetAll().ToList();
            }

            return View(Sucursal);
        }

        [HttpPost]
        public ActionResult Create(SucursaleViewModel sucursaleViewModel)
        {
            Sucursal Sucursal = this.Convertir(sucursaleViewModel);

            using (UnidadDeTrabajo<Sucursal> unidad = new UnidadDeTrabajo<Sucursal>(new DBContext()))
            {
                unidad.genericDAL.Add(Sucursal);
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }



        public ActionResult Edit(int id)
        {

            Sucursal Sucursal;

            using (UnidadDeTrabajo<Sucursal> unidad = new UnidadDeTrabajo<Sucursal>(new DBContext()))
            {
                Sucursal = unidad.genericDAL.Get(id);

            }

            SucursaleViewModel sucursaleVM = this.Convertir(Sucursal);

            using (UnidadDeTrabajo<Compania> unidad = new UnidadDeTrabajo<Compania>(new DBContext()))
            {
                sucursaleVM.companias = unidad.genericDAL.GetAll().ToList();
            }

            return View(sucursaleVM);
        }


        [HttpPost]
        public ActionResult Edit(SucursaleViewModel sucursaleViewModel)
        {


            using (UnidadDeTrabajo<Sucursal> unidad = new UnidadDeTrabajo<Sucursal>(new DBContext()))
            {
                unidad.genericDAL.Update(this.Convertir(sucursaleViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {

            Sucursal Sucursal;
            using (UnidadDeTrabajo<Sucursal> unidad = new UnidadDeTrabajo<Sucursal>(new DBContext()))
            {
                Sucursal = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(Sucursal));
        }

        public ActionResult Delete(int id)
        {

            Sucursal Sucursal;
            using (UnidadDeTrabajo<Sucursal> unidad = new UnidadDeTrabajo<Sucursal>(new DBContext()))
            {
                Sucursal = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(Sucursal));
        }

        [HttpPost]
        public ActionResult Delete(SucursaleViewModel sucursaleViewModel)
        {
            using (UnidadDeTrabajo<Sucursal> unidad = new UnidadDeTrabajo<Sucursal>(new DBContext()))
            {
                unidad.genericDAL.Remove(this.Convertir(sucursaleViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}