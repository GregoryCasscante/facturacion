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
    public class UnidadMedidaController : MyBaseController
    {
        // GET: UnidadMedida
        private UnidadMedidaViewModel Convertir(UnidadMedidas unidadMedida)
        {
            UnidadMedidaViewModel unidadMedidaViewModel = new UnidadMedidaViewModel
            {

                id = unidadMedida.id,
                value = unidadMedida.value,
                descripcion = unidadMedida.descripcion

            };
            return unidadMedidaViewModel;
        }



        private UnidadMedidas Convertir(UnidadMedidaViewModel unidadMedidaViewModel)
        {
            UnidadMedidas unidadMedida = new UnidadMedidas
            {
                id = unidadMedidaViewModel.id,
                value = unidadMedidaViewModel.value,
                descripcion = unidadMedidaViewModel.descripcion

            };
            return unidadMedida;
        }

        // GET: UnidadMedida
        public ActionResult Index()
        {
            List<UnidadMedidas> unidadMedidas;

            using (UnidadDeTrabajo<UnidadMedidas> Unidad = new UnidadDeTrabajo<UnidadMedidas>(new DBContext()))
            {
                unidadMedidas = Unidad.genericDAL.GetAll().ToList();
            }

            List<UnidadMedidaViewModel> lista = new List<UnidadMedidaViewModel>();

            foreach (var item in unidadMedidas)
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
        public ActionResult Create(UnidadMedidaViewModel unidadMedidaViewModel)
        {
            UnidadMedidas unidadMedida = this.Convertir(unidadMedidaViewModel);


            using (UnidadDeTrabajo<UnidadMedidas> unidad = new UnidadDeTrabajo<UnidadMedidas>(new DBContext()))
            {
                unidadMedida.id = (unidad.genericDAL.GetAll().Last<UnidadMedidas>().id) + 1;
                unidad.genericDAL.Add(unidadMedida);
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }



        public ActionResult Edit(int id)
        {

            UnidadMedidas unidadMedida;

            using (UnidadDeTrabajo<UnidadMedidas> unidad = new UnidadDeTrabajo<UnidadMedidas>(new DBContext()))
            {
                unidadMedida = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(unidadMedida));
        }


        [HttpPost]
        public ActionResult Edit(UnidadMedidaViewModel unidadMedidaViewModel)
        {


            using (UnidadDeTrabajo<UnidadMedidas> unidad = new UnidadDeTrabajo<UnidadMedidas>(new DBContext()))
            {
                unidad.genericDAL.Update(this.Convertir(unidadMedidaViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {

            UnidadMedidas unidadMedida;

            using (UnidadDeTrabajo<UnidadMedidas> unidad = new UnidadDeTrabajo<UnidadMedidas>(new DBContext()))
            {
                unidadMedida = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(unidadMedida));
        }

        public ActionResult Delete(int id)
        {

            UnidadMedidas unidadMedida;

            using (UnidadDeTrabajo<UnidadMedidas> unidad = new UnidadDeTrabajo<UnidadMedidas>(new DBContext()))
            {
                unidadMedida = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(unidadMedida));
        }

        [HttpPost]
        public ActionResult Delete(UnidadMedidaViewModel unidadMedidaViewModel)
        {
            using (UnidadDeTrabajo<UnidadMedidas> unidad = new UnidadDeTrabajo<UnidadMedidas>(new DBContext()))
            {
                unidad.genericDAL.Remove(this.Convertir(unidadMedidaViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}