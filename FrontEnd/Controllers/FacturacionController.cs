using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackEnd.DAL;
using BackEnd.Entities;
using BackEnd.Libraries;
using FrontEnd.Models;

namespace FrontEnd.Controllers
{
    public class FacturacionController : MyBaseController
    {

        //Inicialización de Clases y Variables
        private DBContext context;

        //Funcion Para Convertir. 
        private FacturaViewModel Convertir(Factura factura)
        {
            return new FacturaViewModel
            {

                numero_factura                          = factura.numero_factura,
                compania                                = factura.compania,
                usuario                                 = factura.usuario,
                tipo_comprobante                        = factura.tipo_comprobante,
                moneda                                  = factura.moneda,
                condicion_venta                         = factura.condicion_venta,
                forma_de_pago                           = factura.forma_de_pago,
                NumeroConsecutivo                       = factura.NumeroConsecutivo,
                clave                                   = factura.clave,
                CodigoActividad                         = factura.CodigoActividad,
                Emisor                                  = factura.Emisor,
                sucursal                                = factura.sucursal,
                cliente                                 = factura.cliente,
                FechaEmision                            = factura.FechaEmision,
                FechaVencimiento                        = factura.FechaVencimiento,
                detalle                                 = factura.detalle,
                total_servicios_gravados                = factura.total_servicios_gravados,
                total_servicios_exentos                 = factura.total_servicios_exentos,
                total_servicios_exonerados              = factura.total_servicios_exonerados,
                total_mercaderia_gravados               = factura.total_mercaderia_gravados,
                total_mecaderia_exentas                 = factura.total_mecaderia_exentas,
                total_mecaderia_exoneradas              = factura.total_mecaderia_exoneradas,
                total_gravado                           = factura.total_gravado,
                total_exento                            = factura.total_exento,
                total_exonerado                         = factura.total_exonerado,
                total_venta                             = factura.total_venta,
                total_descuentos                        = factura.total_descuentos,
                total_venta_neta                        = factura.total_venta_neta,
                total_impuesto                          = factura.total_impuesto,
                total_comprobante                       = factura.total_comprobante,
                notas                                   = factura.notas


            };

        }
        //Final Convertir




        // GET: Facturacion
        public ActionResult Index()
        {
            //Crear Objecto Factura
            FacturaViewModel Factura = new FacturaViewModel { };

            //Traer Datos Secundarios
            using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(new DBContext()))
            {
                Factura.F_lista_clientes = unidad.genericDAL.GetAll().ToList();
            }









            return View(Factura);
        }
    }
}