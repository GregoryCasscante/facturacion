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
    public class ClienteController : Controller
    {
        // GET: Cliente
        private ClienteViewModel Convertir(Cliente cliente)
        {
            ClienteViewModel clienteViewModel = new ClienteViewModel
            {

                id = cliente.id,
                id_compania = cliente.id_compania,
                identificacion = cliente.identificacion,
                tipo_identificacion = cliente.tipo_identificacion,
                actividad_economica = cliente.actividad_economica,
                nombre = cliente.nombre,
                genero = cliente.genero,
                email1 = cliente.email1,
                email2 = cliente.email2,
                telefono1 = cliente.telefono1,
                telefono2 = cliente.telefono2,
                pais = cliente.pais,
                provincia = cliente.provincia,
                canton = cliente.canton,
                distrito = cliente.distrito,
                dirrecion = cliente.dirrecion,
                fecha_creacion = DateTime.Now

            };
            return clienteViewModel;
        }



        private Cliente Convertir(ClienteViewModel clienteViewModel)
        {
            Cliente cliente = new Cliente
            {
                id = clienteViewModel.id,
                id_compania = clienteViewModel.id_compania,
                identificacion = clienteViewModel.identificacion,
                tipo_identificacion = clienteViewModel.tipo_identificacion,
                actividad_economica = clienteViewModel.actividad_economica,
                nombre = clienteViewModel.nombre,
                genero = clienteViewModel.genero,
                email1 = clienteViewModel.email1,
                email2 = clienteViewModel.email2,
                telefono1 = clienteViewModel.telefono1,
                telefono2 = clienteViewModel.telefono2,
                pais = clienteViewModel.pais,
                provincia = clienteViewModel.provincia,
                canton = clienteViewModel.canton,
                distrito = clienteViewModel.distrito,
                dirrecion = clienteViewModel.dirrecion,
                fecha_creacion = DateTime.Now

            };
            return cliente;
        }

        // GET: Cliente
        public ActionResult Index()
        {
            List<Cliente> clientes;
            using (UnidadDeTrabajo<Cliente> Unidad = new UnidadDeTrabajo<Cliente>(new DBContext()))
            {
                clientes = Unidad.genericDAL.GetAll().ToList();
            }

            List<ClienteViewModel> lista = new List<ClienteViewModel>();

            foreach (var item in clientes)
            {
                lista.Add(this.Convertir(item));
            }

            return View(lista);
        }

        public ActionResult Create()
        {
            ClienteViewModel cliente = new ClienteViewModel { };

            using (UnidadDeTrabajo<Compania> unidad = new UnidadDeTrabajo<Compania>(new DBContext()))
            {
                cliente.companias = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Identificacion_Tipos> unidad = new UnidadDeTrabajo<Identificacion_Tipos>(new DBContext()))
            {
                cliente.identificacion_tipos = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Actividades_Economicas> unidad = new UnidadDeTrabajo<Actividades_Economicas>(new DBContext()))
            {
                cliente.actividades_economicas = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Compania> unidad = new UnidadDeTrabajo<Compania>(new DBContext()))
            {
                cliente.companias = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Pais> unidad = new UnidadDeTrabajo<Pais>(new DBContext()))
            {
                cliente.paises = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Provincia> unidad = new UnidadDeTrabajo<Provincia>(new DBContext()))
            {
                cliente.provincias = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Canton> unidad = new UnidadDeTrabajo<Canton>(new DBContext()))
            {
                cliente.cantones = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Distrito> unidad = new UnidadDeTrabajo<Distrito>(new DBContext()))
            {
                cliente.distritos = unidad.genericDAL.GetAll().ToList();
            }

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
            Cliente cliente = this.Convertir(clienteViewModel);

            using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(new DBContext()))
            {
                unidad.genericDAL.Add(cliente);
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }



        public ActionResult Edit(int id)
        {

            Cliente cliente;
            using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(new DBContext()))
            {
                cliente = unidad.genericDAL.Get(id);

            }

            ClienteViewModel clienteVM = this.Convertir(cliente);

            using (UnidadDeTrabajo<Compania> unidad = new UnidadDeTrabajo<Compania>(new DBContext()))
            {
                clienteVM.companias = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Identificacion_Tipos> unidad = new UnidadDeTrabajo<Identificacion_Tipos>(new DBContext()))
            {
                clienteVM.identificacion_tipos = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Actividades_Economicas> unidad = new UnidadDeTrabajo<Actividades_Economicas>(new DBContext()))
            {
                clienteVM.actividades_economicas = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Compania> unidad = new UnidadDeTrabajo<Compania>(new DBContext()))
            {
                clienteVM.companias = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Pais> unidad = new UnidadDeTrabajo<Pais>(new DBContext()))
            {
                clienteVM.paises = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Provincia> unidad = new UnidadDeTrabajo<Provincia>(new DBContext()))
            {
                clienteVM.provincias = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Canton> unidad = new UnidadDeTrabajo<Canton>(new DBContext()))
            {
                clienteVM.cantones = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Distrito> unidad = new UnidadDeTrabajo<Distrito>(new DBContext()))
            {
                clienteVM.distritos = unidad.genericDAL.GetAll().ToList();
            }

            return View(clienteVM);
        }


        [HttpPost]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {


            using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(new DBContext()))
            {
                unidad.genericDAL.Update(this.Convertir(clienteViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {

            Cliente cliente;
            using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(new DBContext()))
            {
                cliente = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(cliente));
        }

        public ActionResult Delete(int id)
        {

            Cliente cliente;
            using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(new DBContext()))
            {
                cliente = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(cliente));
        }

        [HttpPost]
        public ActionResult Delete(ClienteViewModel clienteViewModel)
        {
            using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(new DBContext()))
            {
                unidad.genericDAL.Remove(this.Convertir(clienteViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }


    }
}
