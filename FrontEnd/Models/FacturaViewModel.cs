using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackEnd.DAL;
using FrontEnd.Models;
using System.ComponentModel.DataAnnotations;
using BackEnd.Entities;

namespace FrontEnd.Models
{
    public class FacturaViewModel

    {
        [Display(Name = "Número de Factura")]
        [Key]
        public int numero_factura { get; set; }

        [Display(Name = "Compania")]
        [Required(ErrorMessage = "Debe de selecionar una Compañia")]
        public int compania { get; set; }
        public int usuario { get; set; }
        public int tipo_comprobante { get; set; }
        public int monera { get; set; }
        public int condicion_venta { get; set; }
        public int forma_de_pago { get; set; }
        public string NumeroConsecutivo { get; set; }
        public string clave { get; set; }
        public int CodigoActividad { get; set; }
        public string Emisor { get; set; }
        public int sucursal { get; set; }
        public int cliente { get; set; }
        public int moneda { get; set; }
        public System.DateTime FechaEmision { get; set; }
        public System.DateTime FechaVencimiento { get; set; }
        public string detalle { get; set; }
        public decimal total_servicios_gravados { get; set; }
        public decimal total_servicios_exentos { get; set; }
        public decimal total_servicios_exonerados { get; set; }
        public decimal total_mercaderia_gravados { get; set; }
        public decimal total_mecaderia_exentas { get; set; }
        public decimal total_mecaderia_exoneradas { get; set; }
        public decimal total_gravado { get; set; }
        public decimal total_exento { get; set; }
        public decimal total_exonerado { get; set; }
        public decimal total_venta { get; set; }
        public decimal total_descuentos { get; set; }
        public decimal total_venta_neta { get; set; }
        public decimal total_impuesto { get; set; }
        public decimal total_comprobante { get; set; }
        public string  notas { get; set; }

        public virtual Actividades_Economica F_Actividades_Economica { get; set; }
        public virtual Cliente F_Cliente { get; set; }
        public virtual Compania F_Compania { get; set; }
        public virtual Condiciones_de_Venta F_Condiciones_de_Ventas { get; set; }
        
        public virtual ICollection<Detalle_Factura> Detalle_Facturas { get; set; }

        public virtual Tipo_Comprobantes F_Tipo_Comprobante { get; set; }
        public virtual Formas_de_pago F_Formas_de_pago { get; set; }
        public virtual Sucursal F_Sucursal { get; set; }
        public virtual Tipo_de_cambio F_Tipo_de_cambio { get; set; }
        public virtual Usuario F_Usuario { get; set; }

        //Valores necesarios para dropdown menus. 
        public IEnumerable<Cliente> F_lista_clientes { get; set; }

    }
}