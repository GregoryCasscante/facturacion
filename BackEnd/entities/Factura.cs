//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackEnd.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Factura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Factura()
        {
            this.Detalle_Facturas = new HashSet<Detalle_Factura>();
        }
    
        public int numero_factura { get; set; }
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
        public string notas { get; set; }
    
        public virtual Actividad_Economica Actividades_Economicas { get; set; }
        public virtual Cliente Clientes { get; set; }
        public virtual Compania Companias { get; set; }
        public virtual Condicion_de_Venta Condiciones_de_Ventas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_Factura> Detalle_Facturas { get; set; }
        public virtual Tipo_Comprobante Tipo_Comprobantes { get; set; }
        public virtual Forma_de_pago Formas_de_pagos { get; set; }
        public virtual Sucursale Sucursales { get; set; }
        public virtual Tipo_de_cambio Tipo_de_cambio { get; set; }
        public virtual Usuario Usuarios { get; set; }
    }
}
