﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI.Models.Rs.NEW
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BDJULIACAEntities3 : DbContext
    {
        public BDJULIACAEntities3()
            : base("name=BDJULIACAEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BANNER> BANNER { get; set; }
        public virtual DbSet<CIUDAD> CIUDAD { get; set; }
        public virtual DbSet<CONFIGURADOR> CONFIGURADOR { get; set; }
        public virtual DbSet<DELIVERYPRECIO> DELIVERYPRECIO { get; set; }
        public virtual DbSet<DIRECUSUARIO> DIRECUSUARIO { get; set; }
        public virtual DbSet<PEDIDO> PEDIDO { get; set; }
        public virtual DbSet<PEDIDODETALLE> PEDIDODETALLE { get; set; }
        public virtual DbSet<PRODUCTOS> PRODUCTOS { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TIENDAS> TIENDAS { get; set; }
        public virtual DbSet<TIPOPAGO> TIPOPAGO { get; set; }
        public virtual DbSet<TIPOSPRODUCTO> TIPOSPRODUCTO { get; set; }
        public virtual DbSet<TIPOUSUARIO> TIPOUSUARIO { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
    }
}
