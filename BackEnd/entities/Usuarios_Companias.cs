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
    
    public partial class Usuarios_Companias
    {
        public int id_usuario { get; set; }
        public int id_compania { get; set; }
        public System.DateTime creado { get; set; }
    
        public virtual Compania Compania { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
