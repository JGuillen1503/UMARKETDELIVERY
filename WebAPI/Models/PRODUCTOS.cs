namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRODUCTOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTOS()
        {
            PEDIDODETALLE = new HashSet<PEDIDODETALLE>();
        }

        [Key]
        public Guid IdProducto { get; set; }

        [StringLength(150)]
        public string DescProducto { get; set; }

        public decimal? PrecProducto { get; set; }

        public bool? EstadoProducto { get; set; }

        public int? IdTipoProducto { get; set; }

        [MaxLength(1)]
        public byte[] IMGProducto { get; set; }

        [StringLength(100)]
        public string ProductoFileName { get; set; }

        public Guid? IdTienda { get; set; }

        public DateTime? FechaCreacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PEDIDODETALLE> PEDIDODETALLE { get; set; }

        public virtual TIENDAS TIENDAS { get; set; }

        public virtual TIPOSPRODUCTO TIPOSPRODUCTO { get; set; }
    }
}
