//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackEnd.entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tipo_de_cambio
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public decimal compra { get; set; }
        public decimal venta { get; set; }
        public Nullable<System.DateTime> fecha_actualizacion { get; set; }
    
        public virtual Factura Factura { get; set; }
    }
}