﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Actividades_Economicas> Actividades_Economicas { get; set; }
        public virtual DbSet<Canton> Cantones { get; set; }
        public virtual DbSet<Categorias_Productos> Categorias_Productos { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Codigo_Impuestos> Codigo_Impuestos { get; set; }
        public virtual DbSet<Compania> Companias { get; set; }
        public virtual DbSet<Condiciones_de_Ventas> Condiciones_de_Ventas { get; set; }
        public virtual DbSet<Consecutivos_Facturas> Consecutivos_Facturas { get; set; }
        public virtual DbSet<Detalle_Facturas> Detalle_Facturas { get; set; }
        public virtual DbSet<Distrito> Distritos { get; set; }
        public virtual DbSet<Facturas> Facturas { get; set; }
        public virtual DbSet<Formas_de_pagos> Formas_de_pagos { get; set; }
        public virtual DbSet<Identificacion_Tipos> Identificacion_Tipos { get; set; }
        public virtual DbSet<Inventarios> Inventarios { get; set; }
        public virtual DbSet<Mantenimientos> Mantenimientos { get; set; }
        public virtual DbSet<Padron_Electoral> Padron_Electoral { get; set; }
        public virtual DbSet<Padron_Electoral_codelec> Padron_Electoral_codelec { get; set; }
        public virtual DbSet<Pais> Paises { get; set; }
        public virtual DbSet<Proveedor> Proveedores { get; set; }
        public virtual DbSet<Provincia> Provincias { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Sucursal> Sucursales { get; set; }
        public virtual DbSet<Tipo_Compania> Tipo_Compania { get; set; }
        public virtual DbSet<Tipo_Comprobantes> Tipo_Comprobantes { get; set; }
        public virtual DbSet<Tipo_de_cambio> Tipo_de_cambio { get; set; }
        public virtual DbSet<UnidadMedidas> UnidadMedidas { get; set; }
        public virtual DbSet<User_Roles> User_Roles { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Usuarios_Companias> Usuarios_Companias { get; set; }
        public virtual DbSet<Usuarios_Login> Usuarios_Logins { get; set; }
    }
}
