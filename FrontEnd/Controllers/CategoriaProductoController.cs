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
    public class CategoriaProductoController : MyBaseController
    {
        // GET: CategoriaProducto
        private CategoriaProductoViewModel Convertir(Categorias_Productos categorias_Productos)
        {
            CategoriaProductoViewModel categorias_ProductosViewModel = new CategoriaProductoViewModel
            {

                id = categorias_Productos.id,
                nombre = categorias_Productos.nombre,
                detalle = categorias_Productos.detalle,
                minimo = categorias_Productos.minimo,
                ventaMinimo = categorias_Productos.ventaMinimo,
                execento = categorias_Productos.execento,
                precio = categorias_Productos.precio

            };
            return categorias_ProductosViewModel;
        }



        private Categorias_Productos Convertir(CategoriaProductoViewModel categorias_ProductosViewModel)
        {
            Categorias_Productos categorias_Productos = new Categorias_Productos
            {
                id = categorias_ProductosViewModel.id,
                nombre = categorias_ProductosViewModel.nombre,
                detalle = categorias_ProductosViewModel.detalle,
                minimo = categorias_ProductosViewModel.minimo,
                ventaMinimo = categorias_ProductosViewModel.ventaMinimo,
                execento = categorias_ProductosViewModel.execento,
                precio = categorias_ProductosViewModel.precio

            };
            return categorias_Productos;
        }

        // GET: Categorias_Productos
        public ActionResult Index()
        {
            List<Categorias_Productos> categorias_Productoss;

            using (UnidadDeTrabajo<Categorias_Productos> Unidad = new UnidadDeTrabajo<Categorias_Productos>(new DBContext()))
            {
                categorias_Productoss = Unidad.genericDAL.GetAll().ToList();
            }

            List<CategoriaProductoViewModel> lista = new List<CategoriaProductoViewModel>();

            foreach (var item in categorias_Productoss)
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
        public ActionResult Create(CategoriaProductoViewModel categorias_ProductosViewModel)
        {
            Categorias_Productos categorias_Productos = this.Convertir(categorias_ProductosViewModel);

            using (UnidadDeTrabajo<Categorias_Productos> unidad = new UnidadDeTrabajo<Categorias_Productos>(new DBContext()))
            {
                unidad.genericDAL.Add(categorias_Productos);
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }



        public ActionResult Edit(int id)
        {

            Categorias_Productos categorias_Productos;

            using (UnidadDeTrabajo<Categorias_Productos> unidad = new UnidadDeTrabajo<Categorias_Productos>(new DBContext()))
            {
                categorias_Productos = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(categorias_Productos));
        }


        [HttpPost]
        public ActionResult Edit(CategoriaProductoViewModel categorias_ProductosViewModel)
        {


            using (UnidadDeTrabajo<Categorias_Productos> unidad = new UnidadDeTrabajo<Categorias_Productos>(new DBContext()))
            {
                unidad.genericDAL.Update(this.Convertir(categorias_ProductosViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {

            Categorias_Productos categorias_Productos;

            using (UnidadDeTrabajo<Categorias_Productos> unidad = new UnidadDeTrabajo<Categorias_Productos>(new DBContext()))
            {
                categorias_Productos = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(categorias_Productos));
        }

        public ActionResult Delete(int id)
        {

            Categorias_Productos categorias_Productos;

            using (UnidadDeTrabajo<Categorias_Productos> unidad = new UnidadDeTrabajo<Categorias_Productos>(new DBContext()))
            {
                categorias_Productos = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(categorias_Productos));
        }

        [HttpPost]
        public ActionResult Delete(CategoriaProductoViewModel categorias_ProductosViewModel)
        {
            using (UnidadDeTrabajo<Categorias_Productos> unidad = new UnidadDeTrabajo<Categorias_Productos>(new DBContext()))
            {
                unidad.genericDAL.Remove(this.Convertir(categorias_ProductosViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}