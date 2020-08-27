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
    public class TipoCambioController : MyBaseController
    {
        // GET: TipoCambio
        private TipoCambioViewModel Convertir(Tipo_de_cambio tipo_de_cambio)
        {
            TipoCambioViewModel tipo_de_cambioViewModel = new TipoCambioViewModel
            {

                id = tipo_de_cambio.id,
                Nombre = tipo_de_cambio.Nombre,
                compra = tipo_de_cambio.compra,
                venta = tipo_de_cambio.venta,
                fecha_actualizacion = tipo_de_cambio.fecha_actualizacion

            };
            return tipo_de_cambioViewModel;
        }



        private Tipo_de_cambio Convertir(TipoCambioViewModel tipo_de_cambioViewModel)
        {
            Tipo_de_cambio tipo_de_cambio = new Tipo_de_cambio
            {
                id = tipo_de_cambioViewModel.id,
                Nombre = tipo_de_cambioViewModel.Nombre,
                compra = tipo_de_cambioViewModel.compra,
                venta = tipo_de_cambioViewModel.venta,
                fecha_actualizacion = tipo_de_cambioViewModel.fecha_actualizacion


            };
            return tipo_de_cambio;
        }

        // GET: Tipo_de_cambio
        public ActionResult Index()
        {
            List<Tipo_de_cambio> tipo_de_cambios;

            using (UnidadDeTrabajo<Tipo_de_cambio> Unidad = new UnidadDeTrabajo<Tipo_de_cambio>(new DBContext()))
            {
                tipo_de_cambios = Unidad.genericDAL.GetAll().ToList();
            }

            List<TipoCambioViewModel> lista = new List<TipoCambioViewModel>();

            foreach (var item in tipo_de_cambios)
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
        public ActionResult Create(TipoCambioViewModel tipo_de_cambioViewModel)
        {
            Tipo_de_cambio tipo_de_cambio = this.Convertir(tipo_de_cambioViewModel);

            using (UnidadDeTrabajo<Tipo_de_cambio> unidad = new UnidadDeTrabajo<Tipo_de_cambio>(new DBContext()))
            {
                tipo_de_cambio.fecha_actualizacion = DateTime.Now;
                unidad.genericDAL.Add(tipo_de_cambio);
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }



        public ActionResult Edit(int id)
        {

            Tipo_de_cambio tipo_de_cambio;

            using (UnidadDeTrabajo<Tipo_de_cambio> unidad = new UnidadDeTrabajo<Tipo_de_cambio>(new DBContext()))
            {
                tipo_de_cambio = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(tipo_de_cambio));
        }


        [HttpPost]
        public ActionResult Edit(TipoCambioViewModel tipo_de_cambioViewModel)
        {


            using (UnidadDeTrabajo<Tipo_de_cambio> unidad = new UnidadDeTrabajo<Tipo_de_cambio>(new DBContext()))
            {
                tipo_de_cambioViewModel.fecha_actualizacion = DateTime.Now;
                unidad.genericDAL.Update(this.Convertir(tipo_de_cambioViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {

            Tipo_de_cambio tipo_de_cambio;

            using (UnidadDeTrabajo<Tipo_de_cambio> unidad = new UnidadDeTrabajo<Tipo_de_cambio>(new DBContext()))
            {
                tipo_de_cambio = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(tipo_de_cambio));
        }

        public ActionResult Delete(int id)
        {

            Tipo_de_cambio tipo_de_cambio;

            using (UnidadDeTrabajo<Tipo_de_cambio> unidad = new UnidadDeTrabajo<Tipo_de_cambio>(new DBContext()))
            {
                tipo_de_cambio = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(tipo_de_cambio));
        }

        [HttpPost]
        public ActionResult Delete(TipoCambioViewModel tipo_de_cambioViewModel)
        {
            using (UnidadDeTrabajo<Tipo_de_cambio> unidad = new UnidadDeTrabajo<Tipo_de_cambio>(new DBContext()))
            {
                unidad.genericDAL.Remove(this.Convertir(tipo_de_cambioViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}