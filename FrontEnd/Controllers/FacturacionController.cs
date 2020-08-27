using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;
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

                numero_factura = factura.numero_factura,
                compania = factura.compania,
                usuario = factura.usuario,
                tipo_comprobante = factura.tipo_comprobante,
                moneda = factura.moneda,
                condicion_venta = factura.condicion_venta,
                forma_de_pago = factura.forma_de_pago,
                NumeroConsecutivo = factura.NumeroConsecutivo,
                clave = factura.clave,
                CodigoActividad = factura.CodigoActividad,
                Emisor = factura.Emisor,
                sucursal = factura.sucursal,
                cliente = factura.cliente,
                FechaEmision = factura.FechaEmision,
                FechaVencimiento = factura.FechaVencimiento,
                detalle = factura.detalle,
                total_servicios_gravados = factura.total_servicios_gravados,
                total_servicios_exentos = factura.total_servicios_exentos,
                total_servicios_exonerados = factura.total_servicios_exonerados,
                total_mercaderia_gravados = factura.total_mercaderia_gravados,
                total_mecaderia_exentas = factura.total_mecaderia_exentas,
                total_mecaderia_exoneradas = factura.total_mecaderia_exoneradas,
                total_gravado = factura.total_gravado,
                total_exento = factura.total_exento,
                total_exonerado = factura.total_exonerado,
                total_venta = factura.total_venta,
                total_descuentos = factura.total_descuentos,
                total_venta_neta = factura.total_venta_neta,
                total_impuesto = factura.total_impuesto,
                total_comprobante = factura.total_comprobante,
                notas = factura.notas


            };

        }
        //Final Convertir




        // GET: Facturacion
        public ActionResult Index()
        {
            //Crear Objecto Factura
            FacturaViewModel Factura = new FacturaViewModel { };

            //Traer Datos Secundarios

            ICompaniaDAL companiaDAL = new CompaniaDALImpl();
            Factura.F_lista_companias = companiaDAL.Get();

            //using (UnidadDeTrabajo<Compania> unidad = new UnidadDeTrabajo<Compania>(new DBContext()))
            //{
            //  Factura.F_lista_companias = unidad.genericDAL.GetAll().ToList();
            //}
            using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(new DBContext()))
            {
                Factura.F_lista_clientes = unidad.genericDAL.GetAll().ToList();
            }
            using (UnidadDeTrabajo<Condiciones_de_Venta> unidad = new UnidadDeTrabajo<Condiciones_de_Venta>(new DBContext()))
            {
                Factura.F_lista_Condiciones_de_Venta = unidad.genericDAL.GetAll().ToList();
            }
            using (UnidadDeTrabajo<Inventarios> unidad = new UnidadDeTrabajo<Inventarios>(new DBContext()))
            {
                Factura.F_lista_Productos = unidad.genericDAL.GetAll().ToList();
            }
            using (UnidadDeTrabajo<Tipo_Comprobantes> unidad = new UnidadDeTrabajo<Tipo_Comprobantes>(new DBContext()))
            {
                Factura.F_lista_Tipo_Comprobante = unidad.genericDAL.GetAll().ToList();
            }

            return View(Factura);
        }


        /*
         *************************************************************************************************************************** 
         *************************************************************************************************************************** 
         *************************************************************************************************************************** 
         ***************************************************************************************************************************  
         ***************************************************************************************************************************
         */

        [HttpPost]
        public ActionResult Create(Factura f)
        {

            //Serializar el arreglo POST
            NameValueCollection r = Request.Form;

            Factura factura = new Factura
            {

                numero_factura = f.numero_factura,
                compania = f.compania,
                usuario = Convert.ToInt32(Session["user.id"]),
                tipo_comprobante = f.tipo_comprobante,
                monera = f.monera,
                condicion_venta = f.condicion_venta,
                forma_de_pago = f.forma_de_pago,
                NumeroConsecutivo = "",  //20digitos
                clave = "",              //50digitos, generar            
                CodigoActividad = 0,   
                Emisor = "Cliente",
                sucursal = 1,  
                cliente = f.cliente,
                moneda = f.moneda,
                FechaEmision = DateTime.Now,
                FechaVencimiento = DateTime.Now.AddDays(30),
                detalle = "Detalle",

                total_servicios_gravados = 0,
                total_servicios_exentos = 0,
                total_servicios_exonerados = 0,
                total_mercaderia_gravados = Convert.ToDecimal(Request["iva"]),
                total_mecaderia_exentas = 0,
                total_mecaderia_exoneradas = 0,
                total_gravado = Convert.ToDecimal(Request["iva"]),
                total_exento = 0,
                total_exonerado = 0,
                total_venta = Convert.ToDecimal(Request["total"]),
                total_descuentos = 0,
                total_venta_neta = Convert.ToDecimal(Request["subtotal"]),
                total_impuesto  = Convert.ToDecimal(Request["iva"]),
                total_comprobante = Convert.ToDecimal(Request["total"]),
                notas = "Notas"

            };


            IUsuarioDAL usuarioDB = new UsuarioDALImpl();
            IFacturaDAL facturaDB = new FacturaDALImpl();

            //Traer Cliente
            Cliente cliente;
            using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(new DBContext()))
            {
                cliente = unidad.genericDAL.Get(factura.cliente);
                ViewBag.cliente = cliente;
            }


            //Traer Compania
            Compania compania;
            using (UnidadDeTrabajo<Compania> unidad = new UnidadDeTrabajo<Compania>(new DBContext()))
            {
                compania = unidad.genericDAL.Get(factura.compania);
                factura.CodigoActividad = compania.actividad_economica;
                ViewBag.compania = compania;
            }

            //Traer Consecutivo
            Consecutivos_Facturas Consecutivo;
            using (UnidadDeTrabajo<Consecutivos_Facturas> unidad = new UnidadDeTrabajo<Consecutivos_Facturas>(new DBContext()))
            {
                Consecutivo = unidad.genericDAL.Get(factura.compania);
            }
            //Generar Consecutivo
            var s_tipo_comprobante = factura.tipo_comprobante.ToString().PadLeft(2, '0');
            var s_consecutivo      = Consecutivo.consecutivo_factura.ToString().PadLeft(10, '0');
            factura.NumeroConsecutivo = "00100001"+ s_tipo_comprobante + s_consecutivo;

            //Gernerar Clave 
            var hoy       = DateTime.Now;
            var dia       = Convert.ToString(hoy.Day).PadLeft(2, '0');
            var mes       = Convert.ToString(hoy.Month).PadLeft(2, '0');
            var year = hoy.ToString("yy");  //Convert.ToString(hoy.Year);
            var ced       = compania.cedula_juridica.PadLeft(12, '0');
            Random number = new Random();

            int num = number.Next(1, 99999999); // _random.Next(1, 99999999);
            var cod_seg = Convert.ToString(num).PadLeft(8, '0');
            var clave = "506" + dia + mes + year + ced + factura.NumeroConsecutivo + "1" + cod_seg;
            
            factura.clave = clave;

            /*
             ##########################################################################################################
             ##########################################################################################################
             ##########################################################################################################
             ##########################################################################################################
             #Crear Factura
            */
            int inserted = facturaDB.Add(factura);
            factura.numero_factura = inserted;


            /*
             ##########################################################################################################
             ##########################################################################################################
             ##########################################################################################################
             ##########################################################################################################
             #Crear Lineas 
            */
            string[] producto1 = Request["producto1"].Split('|');
            Detalle_Factura detalle1 = new Detalle_Factura
            {
                numero_factura = inserted,
                NumeroLinea = 1,
                producto = Convert.ToInt32(producto1[2]),
                LineaDetalle = producto1[0],
                PartidaArancelaria = "",
                UnidadMedida = 1,
                Cantidad = Convert.ToDecimal(Request["cantidad1"]),
                PrecioUnitario = Convert.ToDecimal(producto1[1]),
                MontoDescuento = 0,
                codigo_impuesto = 0,
                Impuesto = Convert.ToDecimal(Request["iva1"]),
                TotalLinea = Convert.ToDecimal(Request["iva1"])
            };

            string[] producto2 = Request["producto2"].Split('|');
            Detalle_Factura detalle2 = new Detalle_Factura
            {
                numero_factura = inserted,
                NumeroLinea = 2,
                producto = Convert.ToInt32(producto2[2]),
                LineaDetalle = producto2[0],
                PartidaArancelaria = "",
                UnidadMedida = 1,
                Cantidad = Convert.ToDecimal(Request["cantidad1"]),
                PrecioUnitario = Convert.ToDecimal(producto2[1]),
                MontoDescuento = 0,
                codigo_impuesto = 0,
                Impuesto = Convert.ToDecimal(Request["iva1"]),
                TotalLinea = Convert.ToDecimal(Request["iva1"])
            };

            string[] producto3 = Request["producto3"].Split('|');
            Detalle_Factura detalle3 = new Detalle_Factura
            {
                numero_factura = inserted,
                NumeroLinea = 3,
                producto = Convert.ToInt32(producto3[2]),
                LineaDetalle = producto3[0],
                PartidaArancelaria = "",
                UnidadMedida = 1,
                Cantidad = Convert.ToDecimal(Request["cantidad1"]),
                PrecioUnitario = Convert.ToDecimal(producto3[1]),
                MontoDescuento = 0,
                codigo_impuesto = 0,
                Impuesto = Convert.ToDecimal(Request["iva1"]),
                TotalLinea = Convert.ToDecimal(Request["iva1"])
            };

            //Insertar Linea. 
            facturaDB.Add_Linea(detalle1);
            facturaDB.Add_Linea(detalle2);
            facturaDB.Add_Linea(detalle3);
            ViewBag.detalle1 = detalle1;
            ViewBag.detalle2 = detalle2;
            ViewBag.detalle3 = detalle3;



            //
            FacturaViewModel factVM = this.Convertir(factura);
            return View(factVM);
            //return RedirectToAction("Index");
        }


    }
}
 