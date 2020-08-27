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
    public class InventarioController : MyBaseController
    {
        // GET: Inventario
        private InventarioViewModel Convertir(Inventarios inventario)
        {
            InventarioViewModel inventarioViewModel = new InventarioViewModel
            {

                id = inventario.id,
                categoria = inventario.categoria,
                proveedor = inventario.proveedor,
                cantidad = inventario.cantidad,
                descripcion = inventario.descripcion,
                minimo = inventario.minimo,
                ventaMinima = inventario.ventaMinima,
                exento = inventario.exento,
                precio = inventario.precio

            };
            return inventarioViewModel;
        }



        private Inventarios Convertir(InventarioViewModel inventarioViewModel)
        {
            Inventarios inventario = new Inventarios
            {
                id = inventarioViewModel.id,
                categoria = inventarioViewModel.categoria,
                proveedor = inventarioViewModel.proveedor,
                cantidad = inventarioViewModel.cantidad,
                descripcion = inventarioViewModel.descripcion,
                minimo = inventarioViewModel.minimo,
                ventaMinima = inventarioViewModel.ventaMinima,
                exento = inventarioViewModel.exento,
                precio = inventarioViewModel.precio

            };
            return inventario;
        }

        // GET: Inventario
        public ActionResult Index()
        {
            List<Inventarios> inventarios;

            using (UnidadDeTrabajo<Inventarios> Unidad = new UnidadDeTrabajo<Inventarios>(new DBContext()))
            {
                inventarios = Unidad.genericDAL.GetAll().ToList();
            }

            List<InventarioViewModel> lista = new List<InventarioViewModel>();

            foreach (var item in inventarios)
            {
                InventarioViewModel inventarioVM = new InventarioViewModel();

                UnidadDeTrabajo<Categorias_Productos> unidadCategoriaProducto = new UnidadDeTrabajo<Categorias_Productos>(new DBContext());
                UnidadDeTrabajo<Proveedor> unidadProveedor = new UnidadDeTrabajo<Proveedor>(new DBContext());

                inventarioVM = this.Convertir(item);
                inventarioVM.nombre_categoria = unidadCategoriaProducto.genericDAL.Get(inventarioVM.categoria).nombre;
                inventarioVM.nombre_proveedor = unidadProveedor.genericDAL.Get(inventarioVM.proveedor).nombre_comercial;

                lista.Add(inventarioVM);
            }

            return View(lista);
        }

        public ActionResult Create()
        {
            InventarioViewModel inventario = new InventarioViewModel { };

            using (UnidadDeTrabajo<Categorias_Productos> unidad = new UnidadDeTrabajo<Categorias_Productos>(new DBContext()))
            {
                inventario.categorias = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Proveedor> unidad = new UnidadDeTrabajo<Proveedor>(new DBContext()))
            {
                inventario.proveedores = unidad.genericDAL.GetAll().ToList();
            }

            return View(inventario);
        }

        [HttpPost]
        public ActionResult Create(InventarioViewModel inventarioViewModel)
        {
            Inventarios inventario = this.Convertir(inventarioViewModel);

            using (UnidadDeTrabajo<Inventarios> unidad = new UnidadDeTrabajo<Inventarios>(new DBContext()))
            {
                unidad.genericDAL.Add(inventario);
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }



        public ActionResult Edit(int id)
        {

            Inventarios inventario;

            using (UnidadDeTrabajo<Inventarios> unidad = new UnidadDeTrabajo<Inventarios>(new DBContext()))
            {
                inventario = unidad.genericDAL.Get(id);

            }

            InventarioViewModel inventarioVM = this.Convertir(inventario);

            using (UnidadDeTrabajo<Categorias_Productos> unidad = new UnidadDeTrabajo<Categorias_Productos>(new DBContext()))
            {
                inventarioVM.categorias = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Proveedor> unidad = new UnidadDeTrabajo<Proveedor>(new DBContext()))
            {
                inventarioVM.proveedores = unidad.genericDAL.GetAll().ToList();
            }

            return View(inventarioVM);
        }


        [HttpPost]
        public ActionResult Edit(InventarioViewModel inventarioViewModel)
        {


            using (UnidadDeTrabajo<Inventarios> unidad = new UnidadDeTrabajo<Inventarios>(new DBContext()))
            {
                unidad.genericDAL.Update(this.Convertir(inventarioViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {

            Inventarios inventario;

            using (UnidadDeTrabajo<Inventarios> unidad = new UnidadDeTrabajo<Inventarios>(new DBContext()))
            {
                inventario = unidad.genericDAL.Get(id);

            }

            InventarioViewModel inventarioVM = new InventarioViewModel();

            UnidadDeTrabajo<Categorias_Productos> unidadCategoriaProducto = new UnidadDeTrabajo<Categorias_Productos>(new DBContext());
            UnidadDeTrabajo<Proveedor> unidadProveedor = new UnidadDeTrabajo<Proveedor>(new DBContext());


            inventarioVM = this.Convertir(inventario);

            inventarioVM.nombre_categoria = unidadCategoriaProducto.genericDAL.Get(inventarioVM.categoria).nombre;
            inventarioVM.nombre_proveedor = unidadProveedor.genericDAL.Get(inventarioVM.proveedor).nombre_comercial;


            return View(inventarioVM);
        }

        public ActionResult Delete(int id)
        {

            Inventarios inventario;

            using (UnidadDeTrabajo<Inventarios> unidad = new UnidadDeTrabajo<Inventarios>(new DBContext()))
            {
                inventario = unidad.genericDAL.Get(id);

            }

            InventarioViewModel inventarioVM = new InventarioViewModel();

            UnidadDeTrabajo<Categorias_Productos> unidadCategoriaProducto = new UnidadDeTrabajo<Categorias_Productos>(new DBContext());
            UnidadDeTrabajo<Proveedor> unidadProveedor = new UnidadDeTrabajo<Proveedor>(new DBContext());


            inventarioVM = this.Convertir(inventario);

            inventarioVM.nombre_categoria = unidadCategoriaProducto.genericDAL.Get(inventarioVM.categoria).nombre;
            inventarioVM.nombre_proveedor = unidadProveedor.genericDAL.Get(inventarioVM.proveedor).nombre_comercial;


            return View(inventarioVM);
        }

        [HttpPost]
        public ActionResult Delete(InventarioViewModel inventarioViewModel)
        {
            using (UnidadDeTrabajo<Inventarios> unidad = new UnidadDeTrabajo<Inventarios>(new DBContext()))
            {
                unidad.genericDAL.Remove(this.Convertir(inventarioViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}