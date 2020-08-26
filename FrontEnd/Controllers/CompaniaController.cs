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
    public class CompaniaController : MyBaseController
    {

        private CompaniaViewModel Convertir(Compania compania)
        {
            CompaniaViewModel companiaViewModel = new CompaniaViewModel
            {

                id = compania.id,
                actividad_economica = compania.actividad_economica,
                nombre = compania.nombre,
                cedula_juridica = compania.cedula_juridica,
                tipo_compania = compania.tipo_compania,
                telefono = compania.telefono,
                nombre_contacto = compania.nombre_contacto,
                apellido1_contacto = compania.apellido1_contacto,
                apellido2_contacto = compania.apellido2_contacto,
                email_contacto = compania.email_contacto,
                direccion = compania.direccion

            };
            return companiaViewModel;
        }



        private Compania Convertir(CompaniaViewModel companiaViewModel)
        {
            Compania compania = new Compania
            {
                id = companiaViewModel.id,
                actividad_economica = companiaViewModel.actividad_economica,
                nombre = companiaViewModel.nombre,
                cedula_juridica = companiaViewModel.cedula_juridica,
                tipo_compania = companiaViewModel.tipo_compania,
                telefono = companiaViewModel.telefono,
                nombre_contacto = companiaViewModel.nombre_contacto,
                apellido1_contacto = companiaViewModel.apellido1_contacto,
                apellido2_contacto = companiaViewModel.apellido2_contacto,
                email_contacto = companiaViewModel.email_contacto,
                direccion = companiaViewModel.direccion


            };
            return compania;
        }

        // GET: Compania
        public ActionResult Index()
        {
            List<Compania> c;
            using (UnidadDeTrabajo<Compania> Unidad = new UnidadDeTrabajo<Compania>(new DBContext()))
            {
                c = Unidad.genericDAL.GetAll().ToList();
            }

            List<CompaniaViewModel> lista = new List<CompaniaViewModel>();

            foreach (var item in c)
            {
                lista.Add(this.Convertir(item));
            }

            return View(lista);
        }

        public ActionResult Create()
        {

            CompaniaViewModel compania = new CompaniaViewModel { };

            using (UnidadDeTrabajo<Actividades_Economica> unidad = new UnidadDeTrabajo<Actividades_Economica>(new DBContext()))
            {
                compania.actividades_economicas = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Tipo_Compania> unidad = new UnidadDeTrabajo<Tipo_Compania>(new DBContext()))
            {
                compania.tipo_companias = unidad.genericDAL.GetAll().ToList();
            }

            return View(compania);
        }

        [HttpPost]
        public ActionResult Create(CompaniaViewModel companiaViewModel)
        {
            Compania compania = this.Convertir(companiaViewModel);

            using (UnidadDeTrabajo<Compania> unidad = new UnidadDeTrabajo<Compania>(new DBContext()))
            {
                unidad.genericDAL.Add(compania);
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }



        public ActionResult Edit(int id)
        {

            Compania compania;
            using (UnidadDeTrabajo<Compania> unidad = new UnidadDeTrabajo<Compania>(new DBContext()))
            {
                compania = unidad.genericDAL.Get(id);

            }

            CompaniaViewModel companiaVM = this.Convertir(compania);

            using (UnidadDeTrabajo<Actividades_Economica> unidad = new UnidadDeTrabajo<Actividades_Economica>(new DBContext()))
            {
                companiaVM.actividades_economicas = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Tipo_Compania> unidad = new UnidadDeTrabajo<Tipo_Compania>(new DBContext()))
            {
                companiaVM.tipo_companias = unidad.genericDAL.GetAll().ToList();
            }

            return View(companiaVM);
        }


        [HttpPost]
        public ActionResult Edit(CompaniaViewModel companiaViewModel)
        {


            using (UnidadDeTrabajo<Compania> unidad = new UnidadDeTrabajo<Compania>(new DBContext()))
            {
                unidad.genericDAL.Update(this.Convertir(companiaViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {

            Compania compania;
            using (UnidadDeTrabajo<Compania> unidad = new UnidadDeTrabajo<Compania>(new DBContext()))
            {
                compania = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(compania));
        }

        public ActionResult Delete(int id)
        {

            Compania compania;
            using (UnidadDeTrabajo<Compania> unidad = new UnidadDeTrabajo<Compania>(new DBContext()))
            {
                compania = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(compania));
        }

        [HttpPost]
        public ActionResult Delete(CompaniaViewModel companiaViewModel)
        {
            using (UnidadDeTrabajo<Compania> unidad = new UnidadDeTrabajo<Compania>(new DBContext()))
            {
                unidad.genericDAL.Remove(this.Convertir(companiaViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }


    }
}