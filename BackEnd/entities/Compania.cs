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
    
    public partial class Compania
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Compania()
        {
            this.Clientes = new HashSet<Cliente>();
            this.Facturas = new HashSet<Factura>();
            this.Usuarios_Companias = new HashSet<Usuarios_Companias>();
            this.Proveedores = new HashSet<Proveedor>();
        }
    
        public int id { get; set; }
        public int actividad_economica { get; set; }
        public int nombre { get; set; }
    
        public virtual Actividades_Economica Actividades_Economicas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Clientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual Proveedor Proveedore { get; set; }
        public virtual Sucursal Sucursale { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuarios_Companias> Usuarios_Companias { get; set; }
        public virtual Consecutivos_Facturas Consecutivos_Facturas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proveedor> Proveedores { get; set; }
    }
}
