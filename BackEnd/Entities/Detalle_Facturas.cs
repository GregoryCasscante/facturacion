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
    
    public partial class Detalle_Facturas
    {
        public int numero_factura { get; set; }
        public int NumeroLinea { get; set; }
        public int producto { get; set; }
        public string LineaDetalle { get; set; }
        public string PartidaArancelaria { get; set; }
        public int UnidadMedida { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal MontoDescuento { get; set; }
        public int codigo_impuesto { get; set; }
        public decimal Impuesto { get; set; }
        public decimal TotalLinea { get; set; }
    
        public virtual Codigo_Impuestos Codigo_Impuestos { get; set; }
        public virtual UnidadMedidas UnidadMedidas { get; set; }
        public virtual Facturas Facturas { get; set; }
    }
}