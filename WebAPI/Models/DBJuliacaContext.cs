namespace WebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBJuliacaContext : DbContext
    {
        public DBJuliacaContext()
            : base("name=DBJuliacaContext")
        {
        }

        public virtual DbSet<BANNER> BANNER { get; set; }
        public virtual DbSet<CIUDAD> CIUDAD { get; set; }
        public virtual DbSet<CONFIGURADOR> CONFIGURADOR { get; set; }
        public virtual DbSet<DELIVERYPRECIO> DELIVERYPRECIO { get; set; }
        public virtual DbSet<DIRECUSUARIO> DIRECUSUARIO { get; set; }
        public virtual DbSet<PEDIDO> PEDIDO { get; set; }
        public virtual DbSet<PEDIDODETALLE> PEDIDODETALLE { get; set; }
        public virtual DbSet<PRODUCTOS> PRODUCTOS { get; set; }
        public virtual DbSet<TIENDAS> TIENDAS { get; set; }
        public virtual DbSet<TIPOPAGO> TIPOPAGO { get; set; }
        public virtual DbSet<TIPOSPRODUCTO> TIPOSPRODUCTO { get; set; }
        public virtual DbSet<TIPOUSUARIO> TIPOUSUARIO { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BANNER>()
                .Property(e => e.IMGBanner)
                .IsFixedLength();

            modelBuilder.Entity<BANNER>()
                .Property(e => e.BannerFileName)
                .IsUnicode(false);

            modelBuilder.Entity<DIRECUSUARIO>()
                .Property(e => e.Longitud)
                .IsUnicode(false);

            modelBuilder.Entity<DIRECUSUARIO>()
                .Property(e => e.Latitud)
                .IsUnicode(false);

            modelBuilder.Entity<DIRECUSUARIO>()
                .Property(e => e.DescDireccion)
                .IsUnicode(false);

            modelBuilder.Entity<PEDIDO>()
                .HasOptional(e => e.PEDIDODETALLE)
                .WithRequired(e => e.PEDIDO);

            modelBuilder.Entity<PEDIDODETALLE>()
                .Property(e => e.CantProducto)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PEDIDODETALLE>()
                .Property(e => e.PrecProducto)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PRODUCTOS>()
                .Property(e => e.PrecProducto)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PRODUCTOS>()
                .Property(e => e.IMGProducto)
                .IsFixedLength();

            modelBuilder.Entity<PRODUCTOS>()
                .Property(e => e.ProductoFileName)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTOS>()
                .HasMany(e => e.PEDIDODETALLE)
                .WithRequired(e => e.PRODUCTOS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TIENDAS>()
                .HasMany(e => e.BANNER)
                .WithRequired(e => e.TIENDAS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.PEDIDO)
                .WithRequired(e => e.USUARIO)
                .WillCascadeOnDelete(false);

        }
    }
}
